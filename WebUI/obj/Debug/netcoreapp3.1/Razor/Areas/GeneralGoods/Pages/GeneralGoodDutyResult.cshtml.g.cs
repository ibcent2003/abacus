#pragma checksum "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "018ecb7bce0dc337794ff720b764ba6db5739442"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Wbc.WebUI.Areas.GeneralGoods.Pages.Areas_GeneralGoods_Pages_GeneralGoodDutyResult), @"mvc.1.0.razor-page", @"/Areas/GeneralGoods/Pages/GeneralGoodDutyResult.cshtml")]
namespace Wbc.WebUI.Areas.GeneralGoods.Pages
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
#line 2 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
using Wbc.Application.Common.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
using Wbc.Application.Common.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
using Wbc.WebUI.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{TransactionId}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"018ecb7bce0dc337794ff720b764ba6db5739442", @"/Areas/GeneralGoods/Pages/GeneralGoodDutyResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8163fe0e9fd95429610aaa944f97b390547c9480", @"/Areas/_ViewImports.cshtml")]
    public class Areas_GeneralGoods_Pages_GeneralGoodDutyResult : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 11 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
  
    ViewData["Title"] = Localizer["PageTitle"];
    Layout = "_PlainLayout";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("PageName", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 19 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
Write(Localizer["PageName"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
            DefineSection("ActivePage", async() => {
                WriteLiteral("\r\n    <nav aria-label=\"breadcrumb\">\r\n        <ol class=\"breadcrumb\">\r\n");
                WriteLiteral("            <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 29 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                              Write(LocalizationService.Get("GeneralGoodResultRes"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n        </ol>\r\n    </nav>\r\n");
            }
            );
#nullable restore
#line 33 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<!-- START SECTION RESULT -->
<div class=""section "">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""heading_s1"">
                    <h2>Duty, Tax and Levies</h2>
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""heading_s1 text-center"">
                    <h5>");
#nullable restore
#line 49 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                   Write(Model.userHscode.HsCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(": ");
#nullable restore
#line 49 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                             Write(Model.userHscode.Keyword);

#line default
#line hidden
#nullable disable
            WriteLiteral(" import into ");
#nullable restore
#line 49 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                                                   Write(Model.country.CountryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                </div>
                <div class=""tab-style1"">
                    <ul class=""nav nav-tabs justify-content-center"" role=""tablist"">
                        <li class=""nav-item"">
                            <a class=""nav-link active"" id=""hscodes-tab"" data-toggle=""tab"" href=""#hscodes"" role=""tab"" aria-controls=""hscodes"" aria-selected=""true"">Duty and Taxes</a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" id=""ra-tab"" data-toggle=""tab"" href=""#ra"" role=""tab"" aria-controls=""ra"" aria-selected=""false"">Regulatory Requirement</a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" id=""ts-tab"" data-toggle=""tab"" href=""#ts"" role=""tab"" aria-controls=""ts"" aria-selected=""false"">Trade Statistics</a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" id=""ln-tab"" data-toggle");
            WriteLiteral(@"=""tab"" href=""#ln"" role=""tab"" aria-controls=""ln"" aria-selected=""false"">Legal Notes</a>
                        </li>
                    </ul>
                    <div class=""tab-content"">
                        <div class=""tab-pane fade show active"" id=""hscodes"" role=""tabpanel"" aria-labelledby=""hscodes-tab"" style=""margin-top: -40px"">
                            <div class=""row"">
                                <div class=""col-md-6"">
                                    <div class=""medium_divider clearfix""></div>
                                    <div class=""heading_s1"">
                                    </div>
                                    <table class=""table table-striped"">
                                        <thead>
                                            <tr>
                                                <th scope=""col"">Product Name</th>
                                                <th scope=""col"">");
#nullable restore
#line 77 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                           Write(Model.userHscode.Keyword);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>HS Code</td>
                                                <td>");
#nullable restore
#line 83 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                               Write(Model.userHscode.HsCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td>Cost(FOB)</td>\r\n                                                <td>");
#nullable restore
#line 87 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                               Write(Model.userHscode.FOB.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td>Insurance</td>\r\n                                                <td>");
#nullable restore
#line 91 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                               Write(Model.userHscode.Insurance.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td>Freight</td>\r\n                                                <td>");
#nullable restore
#line 95 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                               Write(Model.userHscode.Freight.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>

                                <div class=""col-md-6"">
                                    <div class=""medium_divider clearfix""></div>
                                    <div class=""heading_s1"">
                                    </div>
                                    <table class=""table table-striped"">
                                        <thead>
                                            <tr>
                                                <th scope=""col"">Exporting Country</th>
                                                <th scope=""col"">");
#nullable restore
#line 110 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                           Write(Model.Exportingcountry.CountryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Importing Country</td>
                                                <td>");
#nullable restore
#line 116 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                               Write(Model.country.CountryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td>Country</td>\r\n                                                <td>");
#nullable restore
#line 120 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                               Write(Model.currency.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td>Container Size</td>\r\n                                                <td>");
#nullable restore
#line 124 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                               Write(Model.userHscode.ContainerSize);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td>CIF</td>\r\n                                                <td>\r\n");
#nullable restore
#line 129 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                      
                                                        var totalCIF = Model.userHscode.FOB + Model.userHscode.Freight + Model.userHscode.Insurance;

                                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    ");
#nullable restore
#line 133 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                               Write(totalCIF.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

                            <div class=""row"">
                                <div class=""col-md-12"">
                                    <div class=""medium_divider clearfix""></div>
                                    <div class=""heading_s1"">
                                    </div>
                                    <table class=""table table-hover"">
                                        <tbody>
                                            <tr class=""success"">
                                                <td>Standard Unit of Quantity</td>
                                                <td>");
#nullable restore
#line 150 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                               Write(Model.userHscode.StandardUnitOfQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 152 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                             foreach (var t in Model.userTariffExtraTaxes)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr class=\"success\">\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 156 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                   Write(t.TaxName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n\r\n");
#nullable restore
#line 159 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                     if (t.IsRate == true)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>");
#nullable restore
#line 161 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                       Write(t.TaxValue);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</td>\r\n");
#nullable restore
#line 162 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                    }
                                                    else
                                                    {
                                                        if (t == Model.userTariffExtraTaxes.Last())
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <td>");
#nullable restore
#line 167 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                           Write(Model.country.CurrencyCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 167 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                                                       Write(t.TaxValue.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 168 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <td>");
#nullable restore
#line 171 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                           Write(Model.currency.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 171 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                                                Write(t.TaxValue.ToString("#,##0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 172 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                        }
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </tr>\r\n");
#nullable restore
#line 175 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </tbody>\r\n                                    </table>\r\n");
#nullable restore
#line 178 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                     if (Model.HasBechMark == true)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""mb-3"">
                                            <div class=""alert alert-primary alert-outline alert-dismissible"" role=""alert"">
                                                <div class=""alert-message"">
                                                    <p>
                                                        Dear valued customer/trader, your product may attract further depreciation in unit price after declaring  to GRA Customs for valuation and classification  assessment, this is due to the vice president directive of 50% reduction on commodity transactional value/unit price on the 4th of April 2019. <br><br> NB. Benchmark values are transaction values declared by importers and captured in our Tansaction Price Database (TPD); they are used as an internal risk assessment tool  for Customs valuation purposes by the Customs Technical Services Bureau. Benchmark values assist us to quickly assess valuation risks of targetted goods; we also use same to");
            WriteLiteral(@" combat trade misinvoicing in the nature of underinvoicing, overinvoicing, valuation fraud and transfer pricing between related parties.
                                                    </p>
                                                    <hr>
                                                    <div class=""btn-list"">
                                                        <p>Thank You.</p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
");
#nullable restore
#line 193 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </div>
                            </div>


                        </div>


                        <div class=""tab-pane fade"" id=""ra"" role=""tabpanel"" aria-labelledby=""ra-tab"">
                            <div id=""accordion"" class=""accordion accordion_style1"">
                                <div class=""heading_s1"">
                                    <hr />
                                </div>
");
#nullable restore
#line 206 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                 if (Model.agencies.Count() != 0)
                                {


                                    foreach (var a in Model.agencies)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""card"">
                                            <div class=""card-header"" id=""headingOne"">
                                                <h5 class=""mb-0"">
                                                    <a class=""collapsed"" data-toggle=""collapse""");
            BeginWriteAttribute("href", " href=\"", 12355, "\"", 12371, 2);
            WriteAttributeValue("", 12362, "#id_", 12362, 4, true);
#nullable restore
#line 215 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
WriteAttributeValue("", 12366, a.Id, 12366, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-expanded=\"false\" aria-controls=\"collapseOne\">");
#nullable restore
#line 215 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                                                                                                                              Write(a.AgencyName.ToUpper());

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                                </h5>\r\n                                            </div>\r\n                                            <div");
            BeginWriteAttribute("id", " id=\"", 12607, "\"", 12620, 2);
            WriteAttributeValue("", 12612, "id_", 12612, 3, true);
#nullable restore
#line 218 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
WriteAttributeValue("", 12615, a.Id, 12615, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse\" aria-labelledby=\"headingOne\" data-parent=\"#accordion\"");
            BeginWriteAttribute("style", " style=\"", 12692, "\"", 12700, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <div class=\"card-body\">\r\n");
#nullable restore
#line 220 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                     if(Model.AgencyHsCode.Count() != 0)
                                                    {

                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 223 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                     foreach (var t in Model.AgencyHsCode.Where(x=>x.AgencyId==a.Id))
                                                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <div class=\"row\">\r\n                                                            <div class=\"col-md-12\">\r\n                                                                <div class=\"heading_s1\">\r\n\r\n");
#nullable restore
#line 230 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                                     if (t.DocumentType.DocumentTypeName == "Not Required")
                                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                        <h6>Permit ");
#nullable restore
#line 232 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                                              Write(t.DocumentType.DocumentTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 233 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                                    }
                                                                    else
                                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                        <h6>Requirements for ");
#nullable restore
#line 236 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                                                        Write(t.DocumentType.DocumentTypeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 237 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                </div>\r\n                                                            </div>\r\n                                                        </div>\r\n");
            WriteLiteral("                                                        <div class=\"row\">\r\n");
            WriteLiteral("                                                            }\r\n\r\n\r\n                                                        </div>\r\n");
#nullable restore
#line 301 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"

                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <hr />\r\n");
#nullable restore
#line 305 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"

                                                    }

                                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 359 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                    }
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""alert alert_style1 alert-danger"" role=""alert"">
                                <i class=""ion-close-circled""></i>
                                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
                                        <span aria-hidden=""true"">×</span></button>
                               No regulatory requirements has been added.</div>
");
#nullable restore
#line 368 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                            </div>


                        </div>
                        <div class=""tab-pane fade"" id=""ts"" role=""tabpanel"" aria-labelledby=""ts-tab"">
                            <div class=""alert alert_style1 alert-info"" role=""alert"">
                                <i class=""ion-information-circled""></i>
                                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close""><span aria-hidden=""true"">×</span></button>
                                Coming Soon!
                            </div>
                            <div class=""row justify-content-center"">

");
            WriteLiteral(@"                            </div>
                        </div>
                        <div class=""tab-pane fade"" id=""ln"" role=""tabpanel"" aria-labelledby=""ln-tab"">
                            <div class=""heading_s1 mb-3 mb-md-5"" style=""text-align:center"">
                                <h3>SECTION  ");
#nullable restore
#line 432 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                        Write(Model.Sector.RomanFigure);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                <p>");
#nullable restore
#line 433 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                              Write(Model.Sector.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                            <div class=\"heading_s1 mb-3 mb-md-5\" style=\"text-align:center\">\r\n                                <h3>CHAPTER ");
#nullable restore
#line 437 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                                       Write(Model.Segment.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                <p>");
#nullable restore
#line 438 "C:\Users\ibrahim\Source\Repos\Abacus\WebUI\Areas\GeneralGoods\Pages\GeneralGoodDutyResult.cshtml"
                              Write(Html.Raw(Model.Segment.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CommonLocalizationService LocalizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IStringLocalizer<GeneralGoodDutyResultModel> Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wbc.WebUI.Areas.GeneralGoods.Pages.GeneralGoodDutyResultModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Areas.GeneralGoods.Pages.GeneralGoodDutyResultModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Wbc.WebUI.Areas.GeneralGoods.Pages.GeneralGoodDutyResultModel>)PageContext?.ViewData;
        public Wbc.WebUI.Areas.GeneralGoods.Pages.GeneralGoodDutyResultModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591