#pragma checksum "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c22041405a0984e80b03f2c6298e3b309856b4d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Wbc.WebUI.Areas.Admin.Pages.Areas_Admin_Pages_AllCalculatedDutyList), @"mvc.1.0.razor-page", @"/Areas/Admin/Pages/AllCalculatedDutyList.cshtml")]
namespace Wbc.WebUI.Areas.Admin.Pages
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
#line 1 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\_ViewImports.cshtml"
using Wbc.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
using Wbc.Application.Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
using Wbc.Application.Common.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
using Wbc.WebUI.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c22041405a0984e80b03f2c6298e3b309856b4d4", @"/Areas/Admin/Pages/AllCalculatedDutyList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8163fe0e9fd95429610aaa944f97b390547c9480", @"/Areas/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_AllCalculatedDutyList : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/DataTables/datatables.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/DataTables/datatables.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c22041405a0984e80b03f2c6298e3b309856b4d45350", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
            DefineSection("PageName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 19 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
Write(Localizer["PageName"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
            DefineSection("BreadCrumbs", async() => {
                WriteLiteral("\r\n    <nav aria-label=\"breadcrumb\">\r\n        <ol class=\"breadcrumb\">\r\n            <li class=\"breadcrumb-item\"><a href=\"/Dashboard\">");
#nullable restore
#line 27 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
                                                        Write(LocalizationService.Get("DashBoardRes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></li>\r\n            <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 28 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
                                                              Write(LocalizationService.Get("AllCalculatedDutyListRes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n        </ol>\r\n    </nav>\r\n");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 33 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""card"">
    <div class=""card-body"">
        <div class=""table table-responsive"">
            <table id=""vehicleHistory"" class=""table table-striped table-condensed"" style=""width: 100%"">
                <thead>
                    <tr>
                        <th>
                            S/N
                        </th>

                        <th>
                            ");
#nullable restore
#line 46 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
                       Write(Localizer["MakeColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 49 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
                       Write(Localizer["ModelColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 52 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
                       Write(Localizer["YearColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 55 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
                       Write(Localizer["ChassisColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 58 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
                       Write(Localizer["TransactionDateColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 61 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\Admin\Pages\AllCalculatedDutyList.cshtml"
                       Write(Localizer["HDVColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n\r\n                        </th>\r\n\r\n                    </tr>\r\n                </thead>\r\n\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c22041405a0984e80b03f2c6298e3b309856b4d411029", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"


    <script type=""text/javascript"">

        $(document).ready(function () {



            var columns = [
                { ""data"": ""id"", ""orderable"": false },
                { ""data"": ""vehicleMake"", ""orderable"": false },
                { ""data"": ""vehicleModel"", ""orderable"": false },
                { ""data"": ""yearOfManufacture"", ""orderable"": false },
               { ""data"": ""chassisNo"", ""orderable"": false },
                { ""data"": ""transactionDate"", ""orderable"": false },
                { ""data"": ""hdv"", ""orderable"": false }
            ];




                columns.push({
                    ""data"": ""transactionId"",
                    ""orderable"": false,
                    ""sClass"": ""text-center"",
                    ""render"": function(data, type, row)
                    {
                        return '<a  href=""/Admin/CalculatedDutyDetails/' + data + '""><i class=""text-success fas fa-eye""></i> </a>';
                    }
                });


            $('");
                WriteLiteral(@"#vehicleHistory').DataTable({
                ""processing"": true,
                ""serverSide"": true,
                ""responsive"": true,
                ""info"": true,
                ""stateSave"": true,
                ""lengthMenu"":
                [
                    [10, 20, 50, -1], [10, 20, 50, ""All""]
                ],
                ""ajax"": {
                    ""url"":
                        '/Admin/AllCalculatedDutyList',
                    ""type"": ""POST"",
                    headers: {
                        RequestVerificationToken:
                            $('input:hidden[name=""__RequestVerificationToken""]').val()
                    }
                },
                ""fnRowCallback"": function(nRow, aData, iDisplayIndex)
                {
                    $(""td:first"", nRow).html(iDisplayIndex + 1 + this.api().page.info().start);

                    return nRow;
                },
                ""columns"": columns,
                ""order"": [[1, ""asc""]]
    ");
                WriteLiteral("        });\r\n        });\r\n\r\n    </script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CommonLocalizationService LocalizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<AllCalculatedDutyListModel> Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wbc.WebUI.Areas.Admin.Pages.AllCalculatedDutyListModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Areas.Admin.Pages.AllCalculatedDutyListModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Areas.Admin.Pages.AllCalculatedDutyListModel>)PageContext?.ViewData;
        public Wbc.WebUI.Areas.Admin.Pages.AllCalculatedDutyListModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
