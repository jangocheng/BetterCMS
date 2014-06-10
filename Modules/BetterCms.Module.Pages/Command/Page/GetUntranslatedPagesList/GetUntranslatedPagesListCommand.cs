﻿using System.Linq;

using BetterCms.Core.Security;

using BetterCms.Module.Pages.Command.Page.GetPagesList;
using BetterCms.Module.Pages.Models;
using BetterCms.Module.Pages.Services;
using BetterCms.Module.Pages.ViewModels.Filter;
using BetterCms.Module.Pages.ViewModels.SiteSettings;

using BetterCms.Module.Root.Models;
using BetterCms.Module.Root.Services;

using NHibernate.Criterion;

namespace BetterCms.Module.Pages.Command.Page.GetUntranslatedPagesList
{
    public class GetUntranslatedPagesListCommand : GetPagesListCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUntranslatedPagesListCommand" /> class.
        /// </summary>
        /// <param name="categoryService">The category service.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="languageService">The language service.</param>
        /// <param name="accessControlService">The access control service.</param>
        /// <param name="layoutService">The layout service.</param>
        public GetUntranslatedPagesListCommand(ICategoryService categoryService, ICmsConfiguration configuration, 
            ILanguageService languageService, IAccessControlService accessControlService, ILayoutService layoutService)
            : base(categoryService, configuration, languageService, accessControlService, layoutService)
        {
        }

        /// <summary>
        /// Executes the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>
        /// Result model.
        /// </returns>
        public override PagesGridViewModel<SiteSettingPageViewModel> Execute(PagesFilter request)
        {
            var model = base.Execute(request);
            if (model != null)
            {
                model.HideMasterPagesFiltering = true;

                var filter = request as UntranslatedPagesFilter;
                if (model.Languages != null && filter != null && filter.ExcludedLanguageId.HasValue)
                {
                    var languageToExclude = model.Languages.FirstOrDefault(c => c.Key == filter.ExcludedLanguageId.Value.ToString().ToLowerInvariant());
                    if (languageToExclude != null)
                    {
                        model.Languages.Remove(languageToExclude);
                    }
                }
            }

            return model;
        }

        /// <summary>
        /// Creates the model.
        /// </summary>
        /// <param name="pages">The pages.</param>
        /// <param name="request">The request.</param>
        /// <param name="count">The count.</param>
        /// <param name="categoriesFuture">The categories future.</param>
        /// <param name="layouts">The layouts.</param>
        /// <returns>
        /// Model
        /// </returns>
        protected override PagesGridViewModel<SiteSettingPageViewModel> CreateModel(System.Collections.Generic.IEnumerable<SiteSettingPageViewModel> pages, 
            PagesFilter request, NHibernate.IFutureValue<int> count, 
            System.Collections.Generic.IEnumerable<Root.Models.LookupKeyValue> categoriesFuture,
            System.Collections.Generic.IList<Root.Models.LookupKeyValue> layouts) {
            return new UntranslatedPagesGridViewModel<SiteSettingPageViewModel>(
                pages.ToList(),
                request as UntranslatedPagesFilter,
                count.Value,
                categoriesFuture.ToList())
                   {
                       Layouts = layouts
                   };
        }

        /// <summary>
        /// Filters the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="request">The request.</param>
        /// <param name="hasnotSeoDisjunction">The has seo disjunction.</param>
        /// <returns>
        /// Query, filtered with specified filter parameters
        /// </returns>
        protected override NHibernate.IQueryOver<PagesView, PagesView> FilterQuery(NHibernate.IQueryOver<PagesView, PagesView> query,
            PagesFilter request, Junction hasnotSeoDisjunction)
        {
            query = base.FilterQuery(query, request, hasnotSeoDisjunction);

            var filter = request as UntranslatedPagesFilter;
            if (filter != null)
            {
                PageProperties alias = null;

                // Exclude from results
                if (filter.ExistingItemsArray.Any())
                {
                    query = query.Where(Restrictions.Not(Restrictions.In(Projections.Property(() => alias.Id), filter.ExistingItemsArray)));
                }

                // Excluded language id
                if (filter.ExcludedLanguageId.HasValue)
                {
                    var languageProxy = Repository.AsProxy<Root.Models.Language>(filter.ExcludedLanguageId.Value);
                    query = query.Where(() => (alias.Language != languageProxy || alias.Language == null));
                }
                
                if (filter.ExcplicitlyIncludedPagesArray.Any())
                {
                    // Include to results explicitly included or untranslated
                    query = query.Where(Restrictions.Disjunction()
                        .Add(Restrictions.In(Projections.Property(() => alias.Id), filter.ExcplicitlyIncludedPagesArray))
                        .Add(Restrictions.IsNull(Projections.Property(() => alias.LanguageGroupIdentifier))));
                }
                else
                {
                    // Only untranslated
                    query = query.Where(Restrictions.IsNull(Projections.Property(() => alias.LanguageGroupIdentifier)));
                }
            }

            return query;
        }
    }
}