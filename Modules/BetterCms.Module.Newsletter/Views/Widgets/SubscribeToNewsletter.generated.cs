﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BetterCms.Module.Newsletter.Views.Widgets
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
    using BetterCms.Module.Newsletter.Controllers;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
    using Microsoft.Web.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Widgets/SubscribeToNewsletter.cshtml")]
    public partial class SubscribeToNewsletter : System.Web.Mvc.WebViewPage<BetterCms.Module.Newsletter.ViewModels.SubscriberViewModel>
    {
        public SubscribeToNewsletter()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 7 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
  
    // Subscribe to newsletter
    var labelTitle = ViewData["Label title"];
    // Submit
    var submitTitle = ViewData["Submit title"];
    // email...
    var emailPlaceholder = ViewData["Email placeholder"];
    // Submit is disabled
    bool submitDisabled = false;
    if (ViewData["Submit is disabled"] != null)
    {
        if (ViewData["Submit is disabled"] is bool)
        {
            submitDisabled = (bool)ViewData["Submit is disabled"];
        }
        else
        {
            Boolean.TryParse(ViewData["Submit is disabled"].ToString(), out submitDisabled);
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 29 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
 using (Html.BeginForm<SubscriberController>(s => s.Subscribe(null), FormMethod.Post, new { @class = "bcms-newsletter-subscribe-form" }))
{

            
            #line default
            #line hidden
WriteLiteral("    <label");

WriteLiteral(" class=\"bcms-newsletter-subscribe-label\"");

WriteLiteral(" for=\"Email\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
                                                          Write(labelTitle);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"bcms-field-block bcms-newsletter-field-block\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 33 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
   Write(Html.TextBoxFor(m => m.Email, new
                                           {
                                               @type = "email",
                                               @class = "bcms-newsletter-subscribe-input required",
                                               @placeholder = @emailPlaceholder
                                           }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

            
            #line 39 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
   Write(Html.BcmsValidationMessageFor(m => m.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

WriteLiteral("    <button");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" class=\"bcms-newsletter-subscribe-submit\"");

            
            #line 41 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
                                                              Write(submitDisabled ? " disabled=\"disabled\"" : string.Empty);

            
            #line default
            #line hidden
WriteLiteral(">");

            
            #line 41 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
                                                                                                                         Write(submitTitle);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n");

            
            #line 42 "..\..\Views\Widgets\SubscribeToNewsletter.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591