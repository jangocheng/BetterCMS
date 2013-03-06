﻿using System;
using System.Text;

using BetterCms.Core.Models;
using BetterCms.Module.Root.Projections;

namespace BetterCms.Module.Root.Mvc.Helpers
{
    /// <summary>
    /// Helper class for rendering layout section (region) content
    /// </summary>
    public class RegionContentWrapper : IDisposable
    {
        private readonly StringBuilder sb;
        private readonly PageContentProjection content;
        private readonly bool allowContentManagement;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionContentWrapper" /> class.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        /// <param name="content">The region content.</param>
        /// <param name="allowContentManagement">if set to <c>true</c> allows content management.</param>
        public RegionContentWrapper(StringBuilder sb, PageContentProjection content, bool allowContentManagement)
        {
            this.sb = sb;
            this.content = content;
            this.allowContentManagement = allowContentManagement;

            if (allowContentManagement)
            {
                RenderOpeningTags();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (allowContentManagement)
            {
                RenderClosingTags();
            }
        }

        /// <summary>
        /// Renders the opening tags.
        /// </summary>
        private void RenderOpeningTags()
        {
            sb.AppendFormat(@"<script type=""text/html"" data-page-content-id=""{0}"" data-content-id=""{1}"" data-page-content-version=""{2}"" data-content-version=""{3}""{4}>",
                content.PageContentId,
                content.ContentId,
                content.PageContentVersion,
                content.ContentVersion,
                content.PageContentStatus == ContentStatus.Draft ? " data-draft=\"true\"" : null);
            sb.AppendLine();
        }

        /// <summary>
        /// Renders the closing tags.
        /// </summary>
        private void RenderClosingTags()
        {
            if (allowContentManagement)
            {
                sb.AppendLine(@"</script>");
            }
        }
    }
}