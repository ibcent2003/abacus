#pragma checksum "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "046dc53a4d56b4ca9e0d9275c6f20b3e64a95a69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Wbc.WebUI.Pages.Shared.Pages_Shared__MainMenuLatest), @"mvc.1.0.view", @"/Pages/Shared/_MainMenuLatest.cshtml")]
namespace Wbc.WebUI.Pages.Shared
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
#nullable restore
#line 2 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
using IdentityServer4.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
using Microsoft.AspNetCore.Authentication.Cookies;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
using Wbc.Application.Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
using Wbc.Application.Common.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
using Wbc.Application.Common.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
using Wbc.WebUI.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"046dc53a4d56b4ca9e0d9275c6f20b3e64a95a69", @"/Pages/Shared/_MainMenuLatest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ac57be3674e01a0d89b2ab06b1d78ede47ecc41", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__MainMenuLatest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("logo_dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/weblogo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/About", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Pricing", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Documentation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Registration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-fill-out btn-radius border-2 ml-2 btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Signin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n\r\n<header class=\"header_wrap fixed-top dark_skin main_menu_uppercase overlay_bg_white_90 \">\r\n    <div class=\"container\">\r\n        <nav class=\"navbar navbar-expand-lg\">\r\n            <a class=\"navbar-brand\" href=\"/\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "046dc53a4d56b4ca9e0d9275c6f20b3e64a95a699379", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </a>
            <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarSupportedContent"" aria-expanded=""false"">
                <span class=""ion-android-menu""></span>
            </button>
            <div class=""collapse navbar-collapse justify-content-end"" id=""navbarSupportedContent"">
                <ul class=""navbar-nav"">
                    <li");
            BeginWriteAttribute("class", " class=\"", 1066, "\"", 1074, 0);
            EndWriteAttribute();
            WriteLiteral("><a class=\" nav-link active\" href=\"/\">");
#nullable restore
#line 25 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                 Write(Localizer.Get("Home"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                    <li");
            BeginWriteAttribute("class", " class=\"", 1169, "\"", 1177, 0);
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "046dc53a4d56b4ca9e0d9275c6f20b3e64a95a6911728", async() => {
#nullable restore
#line 26 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                  Write(Localizer.Get("About"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 27 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                     if (User.IsAuthenticated())
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 1351, "\"", 1359, 0);
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "046dc53a4d56b4ca9e0d9275c6f20b3e64a95a6913621", async() => {
#nullable restore
#line 29 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                        Write(Localizer.Get("Subscription"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 30 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 1541, "\"", 1549, 0);
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "046dc53a4d56b4ca9e0d9275c6f20b3e64a95a6915526", async() => {
#nullable restore
#line 33 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                        Write(Localizer.Get("Pricing"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 34 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li");
            BeginWriteAttribute("class", " class=\"", 1673, "\"", 1681, 0);
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "046dc53a4d56b4ca9e0d9275c6f20b3e64a95a6917373", async() => {
#nullable restore
#line 35 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                          Write(Localizer.Get("Documentation"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n\r\n\r\n");
#nullable restore
#line 38 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                     if (User.IsAuthenticated())
                    {
                        var userId = User.FindFirst(x => x.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                        {
                            var firstname = User.FindFirst(x => x.Type == ClaimTypes.FirstName.GetAttributeStringValue()).Value;
                            var surname = User.FindFirst(x => x.Type == ClaimTypes.LastName.GetAttributeStringValue()).Value;



#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <li class=""dropdown ml-sm-2"">
                                <a class=""nav-link dropdown-toggle position-relative"" href=""#"" id=""userDropdown"" data-toggle=""dropdown"">
                                    <i class=""align-middle""><b>");
#nullable restore
#line 48 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                          Write(firstname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> ");
#nullable restore
#line 48 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                         Write(surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</i>
                                </a>
                                <div class=""dropdown-menu dropdown-menu-right"" aria-labelledby=""userDropdown"" style=""background-color:none"">
                                    <a class=""dropdown-item"" href=""/dashboard""><i class=""align-middle mr-1 fas fa-fw fa-book""></i> ");
#nullable restore
#line 51 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                                                                              Write(Localizer.Get("MyProfile"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    <a class=\"dropdown-item\" href=\"#\"><i class=\"align-middle mr-1 fas fa-fw fa-cogs\"></i> ");
#nullable restore
#line 52 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                                                                     Write(Localizer.Get("ChangePassword"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    <div class=\"dropdown-divider\"></div>\r\n                                    <a class=\"dropdown-item\" href=\"/Account/Signout\"><i class=\"align-middle mr-1 fas fa-fw fa-arrow-alt-circle-right\"></i> ");
#nullable restore
#line 54 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                                                                                                      Write(Localizer.Get("Logout"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                </div>\r\n                            </li>\r\n");
#nullable restore
#line 57 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"

                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </ul>\r\n");
#nullable restore
#line 62 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                 if (!User.IsAuthenticated())
                {                  

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"header_btn d-sm-block d-none\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "046dc53a4d56b4ca9e0d9275c6f20b3e64a95a6922875", async() => {
#nullable restore
#line 65 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                                                                           Write(Localizer.Get("Register"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "046dc53a4d56b4ca9e0d9275c6f20b3e64a95a6924614", async() => {
#nullable restore
#line 66 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                                                                                                                    Write(Localizer.Get("Login"));

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 68 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Pages\Shared\_MainMenuLatest.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </nav>\r\n    </div>\r\n</header>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ICurrentUserService UserService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CommonLocalizationService Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
