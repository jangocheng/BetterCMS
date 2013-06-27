﻿using System.Runtime.Serialization;

namespace BetterCms.Module.WebApi.Models.Pages.GetHtmlContentById
{
    [DataContract]
    public class GetHtmlContentByIdRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the content id.
        /// </summary>
        /// <value>
        /// The content id.
        /// </value>
        [DataMember(Order = 10, Name = "contentId")]
        public System.Guid ContentId { get; set; }
    }
}