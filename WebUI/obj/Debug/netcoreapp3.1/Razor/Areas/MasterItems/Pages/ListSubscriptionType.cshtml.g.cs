#pragma checksum "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96ee0885581682c76e8d712084dce9732f042018"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Wbc.WebUI.Areas.MasterItems.Pages.Areas_MasterItems_Pages_ListSubscriptionType), @"mvc.1.0.razor-page", @"/Areas/MasterItems/Pages/ListSubscriptionType.cshtml")]
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
#line 2 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
using Wbc.Application.Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
using Wbc.Application.Common.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
using Wbc.WebUI.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96ee0885581682c76e8d712084dce9732f042018", @"/Areas/MasterItems/Pages/ListSubscriptionType.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8163fe0e9fd95429610aaa944f97b390547c9480", @"/Areas/_ViewImports.cshtml")]
    public class Areas_MasterItems_Pages_ListSubscriptionType : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
            WriteLiteral("\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "96ee0885581682c76e8d712084dce9732f0420185429", async() => {
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
#line 16 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
  
    ViewData["Title"] = Localizer["PageTitle"];
    var canUpdate = await AuthorizationService.AuthorizeAsync(User, Policies.CanUpdateSubscriptionType.GetAttributeStringValue());
    var canDelete = await AuthorizationService.AuthorizeAsync(User, Policies.CanDeleteSubscriptionType.GetAttributeStringValue());
    var canAdd = await AuthorizationService.AuthorizeAsync(User, Policies.CanAddSubscriptionType.GetAttributeStringValue());
    


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("PageName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 27 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
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
#line 35 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
                                                        Write(LocalizationService.Get("DashBoardRes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></li>\r\n            <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 36 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
                                                              Write(LocalizationService.Get("ListSubscriptionTypeRes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n        </ol>\r\n    </nav>\r\n");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 41 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-header\">\r\n");
            WriteLiteral(@"        <a href=""/MasterItems/AddSubscriptionType"" class=""btn btn-primary btn-lg""><span class=""fa fa-plus""></span> Add New</a>
    </div>
    <div class=""card-body"">
        <div class=""table table-responsive"">
            <table id=""subscriptionType"" class=""table table-striped table-condensed"" style=""width: 100%"">
                <thead>
                    <tr>
                        <th>
                            S/N
                        </th>
                        <th>
                            ");
#nullable restore
#line 60 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
                       Write(Localizer["SubscriptionTypeNameColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 63 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
                       Write(Localizer["SubscriptionTypeDescriptionColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                       \r\n                        <th>");
#nullable restore
#line 66 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
                       Write(Localizer["IsActiveColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                      \r\n                            <th></th>\r\n                        \r\n                       \r\n                    </tr>\r\n                </thead>\r\n\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96ee0885581682c76e8d712084dce9732f04201810990", async() => {
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
                WriteLiteral("\r\n\r\n\r\n    <script type=\"text/javascript\">\r\n\r\n        $(document).ready(function() {\r\n            var canUpdate = ");
#nullable restore
#line 88 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
                       Write(canUpdate.Succeeded.ToString().ToLower());

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n            var canDelete = ");
#nullable restore
#line 89 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
                       Write(canDelete.Succeeded.ToString().ToLower());

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n\r\n            var deleteBtnlbl = \'");
#nullable restore
#line 91 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
                           Write(LocalizationService.Get("DataTableDeleteBtnlbl"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n            var updateBtnlbl = \'");
#nullable restore
#line 92 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
                           Write(LocalizationService.Get("DataTableUpdateBtnlbl"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n            var isActivelbl = \'");
#nullable restore
#line 93 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionType.cshtml"
                          Write(LocalizationService.Get("IsActivelbl"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';

            var columns = [
                { ""data"": ""id"", ""orderable"": false }, { ""data"": ""name"", ""orderable"": true },
                { ""data"": ""description"", ""orderable"": true },               
                {
                    ""data"": ""isActive"", ""orderable"": false,

                    ""sClass"": ""text-center"",
                    ""render"": function (data, type, row) {
                        if (data) {
                            return '<div class=""custom-control custom-switch""><input type=""checkbox"" class=""custom-control-input"" checked=""true""><label class=""custom-control-label"">Yes</label></div>';
                        }
                        else {
                            return '<div class=""custom-control custom-switch""><input type=""checkbox"" class=""custom-control-input""><label class=""custom-control-label"">NO</label></div>';
                        }
                    }

                }
            ];

           
                columns.push({
           ");
                WriteLiteral(@"         ""data"": ""id"",
                    ""orderable"": false,
                    ""sClass"": ""text-center"",
                    ""render"": function(data, type, row)
                    {
                        return '<a  href=""/MasterItems/UpdateSubscriptionType/' +
                            data +
                            '""><i class=""text-success fas fa-edit""></i> ' +
                            updateBtnlbl +
                            ' </a>';
                    }
                });
            

          

            $('#subscriptionType').DataTable({
                ""processing"": true,
                ""serverSide"": true,
                responsive: true,
                ""info"": true,
                ""stateSave"": true,
                ""lengthMenu"":
                [
                    [10, 20, 50, -1], [10, 20, 50, ""All""]
                ],
                ""ajax"": {
                    ""url"":
                        '/MasterItems/ListSubscriptionType',
           ");
                WriteLiteral(@"         ""type"": ""POST"",
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
        public IStringLocalizer<ListSubscriptionTypeModel> Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wbc.WebUI.Areas.MasterItems.Pages.ListSubscriptionTypeModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Areas.MasterItems.Pages.ListSubscriptionTypeModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Areas.MasterItems.Pages.ListSubscriptionTypeModel>)PageContext?.ViewData;
        public Wbc.WebUI.Areas.MasterItems.Pages.ListSubscriptionTypeModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
