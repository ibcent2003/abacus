#pragma checksum "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\StatusCodeError.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8f49ec099fab245746835449597fa9149164512"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Wbc.WebUI.Pages.Pages_StatusCodeError), @"mvc.1.0.razor-page", @"/Pages/StatusCodeError.cshtml")]
namespace Wbc.WebUI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\_ViewImports.cshtml"
using Wbc.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8f49ec099fab245746835449597fa9149164512", @"/Pages/StatusCodeError.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ac57be3674e01a0d89b2ab06b1d78ede47ecc41", @"/Pages/_ViewImports.cshtml")]
    public class Pages_StatusCodeError : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\StatusCodeError.cshtml"
  

    ViewData["Title"] = @Model.ErrorStatusCode;

    Layout = "_ExceptionLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n\r\n    <h1 class=\"display-1 font-weight-bold\">");
#nullable restore
#line 13 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\StatusCodeError.cshtml"
                                      Write(Model.ErrorStatusCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n    <p class=\"h1\">\r\n\r\n        An error occurred while processing your request.\r\n\r\n");
#nullable restore
#line 19 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\StatusCodeError.cshtml"
         if (Model.ShowRequestId)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h3>Request ID</h3>\r\n                <p>\r\n                    <code>");
#nullable restore
#line 23 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\StatusCodeError.cshtml"
                     Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n                </p>\r\n");
#nullable restore
#line 25 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\StatusCodeError.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </p>\r\n\r\n    <p class=\"h2 font-weight-normal mt-3 mb-4\">The server encountered something unexpected that didn\'t allow it to complete the request.</p>\r\n\r\n");
#nullable restore
#line 30 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\StatusCodeError.cshtml"
     if (Model.ShowOriginalUrl)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 745, "\"", 770, 1);
#nullable restore
#line 32 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\StatusCodeError.cshtml"
WriteAttributeValue("", 752, Model.OriginalUrl, 752, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-lg\">Return to website</a>\r\n");
#nullable restore
#line 33 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\StatusCodeError.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wbc.WebUI.Pages.StatusCodeErrorModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Pages.StatusCodeErrorModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Pages.StatusCodeErrorModel>)PageContext?.ViewData;
        public Wbc.WebUI.Pages.StatusCodeErrorModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
