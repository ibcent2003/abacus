#pragma checksum "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "525a68a9d254a503ae4b26789a8a34f50f315e0b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Wbc.WebUI.Areas.MasterItems.Pages.Areas_MasterItems_Pages_ListSubscriptionPlan), @"mvc.1.0.razor-page", @"/Areas/MasterItems/Pages/ListSubscriptionPlan.cshtml")]
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
#line 2 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
using Wbc.Application.Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
using Wbc.Application.Common.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
using Wbc.WebUI.Areas.MasterItems.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
using Wbc.WebUI.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"525a68a9d254a503ae4b26789a8a34f50f315e0b", @"/Areas/MasterItems/Pages/ListSubscriptionPlan.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8163fe0e9fd95429610aaa944f97b390547c9480", @"/Areas/_ViewImports.cshtml")]
    public class Areas_MasterItems_Pages_ListSubscriptionPlan : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
            WriteLiteral("\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "525a68a9d254a503ae4b26789a8a34f50f315e0b5644", async() => {
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
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 17 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
  
    ViewData["Title"] = Localizer["PageTitle"];
    var canUpdate = await AuthorizationService.AuthorizeAsync(User, Policies.CanUpdateSubscriptionPlan.GetAttributeStringValue());
    var canDelete = await AuthorizationService.AuthorizeAsync(User, Policies.CanDeleteSubscriptionPlan.GetAttributeStringValue());
    var canAdd = await AuthorizationService.AuthorizeAsync(User, Policies.CanAddSubscriptionPlan.GetAttributeStringValue());


#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("PageName", async() => {
                WriteLiteral("\n    ");
#nullable restore
#line 27 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
Write(Localizer["PageName"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
            WriteLiteral("\n\n");
            DefineSection("BreadCrumbs", async() => {
                WriteLiteral("\n    <nav aria-label=\"breadcrumb\">\n        <ol class=\"breadcrumb\">\n            <li class=\"breadcrumb-item\"><a href=\"/Dashboard\">");
#nullable restore
#line 35 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                                                        Write(LocalizationService.Get("DashBoardRes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></li>\n            <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 36 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                                                              Write(LocalizationService.Get("ListSubscriptionPlanRes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\n        </ol>\n    </nav>\n");
            }
            );
            WriteLiteral("\n");
#nullable restore
#line 41 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<div class=\"card\">\n    <div class=\"card-header\">\n");
            WriteLiteral(@"        <a href=""/MasterItems/AddSubscriptionPlan"" class=""btn btn-primary btn-lg""><span class=""fa fa-plus""></span> Add New</a>
    </div>
    <div class=""card-body"">
        <div class=""table table-responsive"">
            <table id=""subPlan"" class=""table table-striped table-condensed"" style=""width: 100%"">
                <thead>
                    <tr>
                        <th>
                            S/N
                        </th>
                        <th>
                            ");
#nullable restore
#line 60 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                       Write(Localizer["SubscriptionPlanNameColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </th>\n                        <th>\n                            ");
#nullable restore
#line 63 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                       Write(Localizer["CountryColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </th>\n                        <th>\n                            ");
#nullable restore
#line 66 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                       Write(Localizer["SubscriptionTypeHeaderColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </th>\n                        <th>\n                            ");
#nullable restore
#line 69 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                       Write(Localizer["AmountHeaderColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </th>\n                        <th>");
#nullable restore
#line 71 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                       Write(Localizer["NoOfUseHeaderColumn"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n\n                      \n                            <th></th>\n                        \n                      \n                    </tr>\n                </thead>\n\n            </table>\n        </div>\n    </div>\n</div>\n\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "525a68a9d254a503ae4b26789a8a34f50f315e0b11788", async() => {
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
                WriteLiteral("\n\n\n    <script type=\"text/javascript\">\n\n        $(document).ready(function () {\n\n            var canUpdate = ");
#nullable restore
#line 95 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                       Write(canUpdate.Succeeded.ToString().ToLower());

#line default
#line hidden
#nullable disable
                WriteLiteral(";\n            var canDelete = ");
#nullable restore
#line 96 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                       Write(canDelete.Succeeded.ToString().ToLower());

#line default
#line hidden
#nullable disable
                WriteLiteral(";\n            var deleteBtnlbl = \'");
#nullable restore
#line 97 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                           Write(LocalizationService.Get("DataTableDeleteBtnlbl"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\n            var updateBtnlbl = \'");
#nullable restore
#line 98 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\MasterItems\Pages\ListSubscriptionPlan.cshtml"
                           Write(LocalizationService.Get("DataTableUpdateBtnlbl"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';

            var columns = [                
                { ""data"": ""id"", ""orderable"": false },
                { ""data"": ""planName"", ""orderable"": true },
                { ""data"": ""countryName"", ""orderable"": true },
                { ""data"": ""subscriptionTypeName"", ""orderable"": true },                
                { ""data"": ""amout"", ""orderable"": false },

                { ""data"": ""noOfUse"", ""orderable"": false }

            ];

          
                columns.push({
                    ""data"": ""id"", ""orderable"": false, ""sClass"": ""text-center"", ""render"": function (data, type, row )
                {
                        return '<a  href=""/MasterItems/UpdateSubscriptionPlan/' + data + '""><i class=""text-success fas fa-edit""></i> ' + updateBtnlbl + ' </a>';

                }});
            

          

            $('#subPlan').DataTable({
                ""processing"": true,
                ""serverSide"": true,
                responsive: true,
                ""info"": true,
                ""stat");
                WriteLiteral(@"eSave"": true,
                ""lengthMenu"":
                [
                    [10, 20, 50, -1], [10, 20, 50, ""All""]
                ],
                ""ajax"": {
                    ""url"":
                        '/MasterItems/ListSubscriptionPlan',
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
        public IStringLocalizer<ListSubscriptionPlanModel> Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wbc.WebUI.Areas.MasterItems.Pages.ListSubscriptionPlanModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Areas.MasterItems.Pages.ListSubscriptionPlanModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Areas.MasterItems.Pages.ListSubscriptionPlanModel>)PageContext?.ViewData;
        public Wbc.WebUI.Areas.MasterItems.Pages.ListSubscriptionPlanModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
