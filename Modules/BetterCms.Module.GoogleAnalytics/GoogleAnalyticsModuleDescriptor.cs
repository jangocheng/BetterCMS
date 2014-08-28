﻿using Autofac;

using BetterCms.Core.Modules;
using BetterCms.Events;
using BetterCms.Module.GoogleAnalytics.Accessors;

namespace BetterCms.Module.GoogleAnalytics
{
    public class GoogleAnalyticsModuleDescriptor : ModuleDescriptor
    {
        internal const string ModuleName = "google_analytics";

        private readonly ICmsConfiguration _cmsConfiguration;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
        {
            get
            {
                return ModuleName;
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public override string Description
        {
            get
            {
                return "The Google Analytics integration module for Better CMS.";
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleAnalyticsModuleDescriptor"/> class
        /// </summary>
        /// <param name="configuration">The configuration</param>
        public GoogleAnalyticsModuleDescriptor(ICmsConfiguration configuration)
            : base(configuration)
        {
            _cmsConfiguration = configuration;
            RootEvents.Instance.PageRendering += Events_PageRendering;
        }

        /// <summary>
        /// Register a routes for the google analytics module.
        /// </summary>
        /// <param name="context">The module context.</param>
        /// <param name="containerBuilder">The container builder.</param>
        public override void RegisterCustomRoutes(ModuleRegistrationContext context, ContainerBuilder containerBuilder)
        {
            context.MapRoute(
                "bcms-google-sitemap",
                GoogleAnalyticsModuleHelper.GetSitemapUrl(_cmsConfiguration),
                new { area = AreaName, controller = "GoogleSitemap", action = "Index" });
        }

        /// <summary>
        /// Add google analytics script accessor to Page.
        /// </summary>
        /// <param name="args">The args.</param>
        private void Events_PageRendering(PageRenderingEventArgs args)
        {
            args.RenderPageData.JavaScripts.Add(new GoogleAnalyticsScriptAccessor(_cmsConfiguration));
        }

    }
}