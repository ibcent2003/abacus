#pragma checksum "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12b5a78c920a16d82af75c1e11a9252e2fbbfb77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Wbc.WebUI.Areas.MasterItems.Pages.Areas_MasterItems_Pages_ListProcess), @"mvc.1.0.razor-page", @"/Areas/MasterItems/Pages/ListProcess.cshtml")]
namespace Wbc.WebUI.Areas.MasterItems.Pages
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
#line 2 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
using Wbc.Application.Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
using Wbc.Application.Common.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
using Wbc.WebUI.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12b5a78c920a16d82af75c1e11a9252e2fbbfb77", @"/Areas/MasterItems/Pages/ListProcess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8163fe0e9fd95429610aaa944f97b390547c9480", @"/Areas/_ViewImports.cshtml")]
    public class Areas_MasterItems_Pages_ListProcess : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/DataTables/datatables.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "AddProcess", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/DataTables/datatables.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "12b5a78c920a16d82af75c1e11a9252e2fbbfb776131", async() => {
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
            WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
  
    ViewData["Title"] = Localizer["PageTitle"];
    var canUpdate = await AuthorizationService.AuthorizeAsync(User, Policies.CanUpdateProcess.GetAttributeStringValue());
    var canDelete = await AuthorizationService.AuthorizeAsync(User, Policies.CanDeleteProcess.GetAttributeStringValue());
    var canAdd = await AuthorizationService.AuthorizeAsync(User, Policies.CanAddProcess.GetAttributeStringValue());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("PageName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 25 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
Write(Localizer["PageName"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("BreadCrumbs", async() => {
                WriteLiteral("\r\n    <nav aria-label=\"breadcrumb\">\r\n        <ol class=\"breadcrumb\">\r\n            <li class=\"breadcrumb-item\"><a href=\"/Dashboard\">");
#nullable restore
#line 32 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                                                        Write(LocalizationService.Get("DashBoardRes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></li>\r\n            <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 33 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                                                              Write(LocalizationService.Get("ListProcessRes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n        </ol>\r\n    </nav>\r\n");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 38 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n");
#nullable restore
#line 42 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
         if (canAdd.Succeeded)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12b5a78c920a16d82af75c1e11a9252e2fbbfb779894", async() => {
                WriteLiteral("<span class=\"fa fa-plus\"></span> Add New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <div class=""card-body"">
        <div class=""table table-responsive"">
            <table id=""requiredDocuments"" class=""table table-striped table-condensed"" style=""width: 100%"">
                <thead>
                    <tr>
                        <th>
                            S/N
                        </th>
                        <th>
                            ");
#nullable restore
#line 56 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                       Write(Localizer["ProcessNameColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 59 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                       Write(Localizer["ProcessDescriptionColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n\r\n");
#nullable restore
#line 62 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                         if (canUpdate.Succeeded)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <th></th>\r\n");
#nullable restore
#line 65 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                         if (canDelete.Succeeded)
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <th></th>\r\n");
#nullable restore
#line 70 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n                </thead>\r\n\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12b5a78c920a16d82af75c1e11a9252e2fbbfb7713739", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n    <script type=\"text/javascript\">\r\n\r\n        $(document).ready(function () {\r\n\r\n            var canUpdate = ");
#nullable restore
#line 89 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                       Write(canUpdate.Succeeded.ToString().ToLower());

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n            var canDelete = ");
#nullable restore
#line 90 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                       Write(canDelete.Succeeded.ToString().ToLower());

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n\r\n            var deleteBtnlbl = \'");
#nullable restore
#line 92 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                           Write(LocalizationService.Get("DataTableDeleteBtnlbl"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n            var updateBtnlbl = \'");
#nullable restore
#line 93 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListProcess.cshtml"
                           Write(LocalizationService.Get("DataTableUpdateBtnlbl"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';

            var columns = [
                { ""data"": ""id"", ""orderable"": false }, { ""data"": ""processName"", ""orderable"": true },
                { ""data"": ""processDescription"", ""orderable"": true }
            ];

            if (canUpdate)
            {
                columns.push({
                    ""data"": ""id"",
                    ""orderable"": false,
                    ""sClass"": ""text-center"",
                    ""render"": function(data, type, row)
                    {
                        return '<a asp-page=""UpdateProcess""   href=""/MasterItems/UpdateProcess/' + data + '""><i class=""text-success fas fa-edit""></i> ' + updateBtnlbl + '</a>';
                    }
                });
            }

            if (canDelete)
            {
                columns.push({
                    ""data"": ""id"",
                    ""orderable"": false,
                    ""sClass"": ""text-center"",
                    ""render"": function(data, type, row)
                    {
        ");
                WriteLiteral(@"                return '<a  href=""/MasterItems/DeleteProcess/' + data + '""><i class=""text-danger fas fa-trash""></i> ' + deleteBtnlbl + '</a>';
                    }
                });
            }

            $('#requiredDocuments').DataTable({
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
                        '/MasterItems/ListProcess',
                    ""type"": ""POST"",
                    headers: {
                        RequestVerificationToken:
                            $('input:hidden[name=""__RequestVerificationToken""]').val()
                    }
                },
                ""fnRowCallback"": function(nRow, aData, iDisplayIndex)
                {
              ");
                WriteLiteral(@"      $(""td:first"", nRow).html(iDisplayIndex + 1 + this.api().page.info().start);

                    return nRow;
                },
                ""columns"": columns,
                ""order"": [[1, ""asc""]]
            });
        });

    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CommonLocalizationService LocalizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<ListProcessModel> Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wbc.WebUI.Areas.MasterItems.Pages.ListProcessModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Areas.MasterItems.Pages.ListProcessModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Areas.MasterItems.Pages.ListProcessModel>)PageContext?.ViewData;
        public Wbc.WebUI.Areas.MasterItems.Pages.ListProcessModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591