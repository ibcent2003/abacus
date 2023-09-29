using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.GeneralGoods.Query;
using Wbc.Application.MasterItems.Query.GetCountry;
using Wbc.Application.TariffManager.Command.CreateSearch;
using Wbc.Domain.Entities;

namespace Wbc.WebUI.Areas.GeneralGoods.Pages
{
    public class GeneralGoodDutyResultModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<GeneralGoodDutyResultModel> _stringLocalizer;
        private readonly IVehicleService _vehicleService;
        private readonly IGeneralGoodsService _generalGoodsService;

        public GeneralGoodDutyResultModel(IMediator mediator, IStringLocalizer<GeneralGoodDutyResultModel> stringLocalizer, IVehicleService vehicleService, IGeneralGoodsService generalGoodsService)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
            _vehicleService = vehicleService;
            _generalGoodsService = generalGoodsService;
        }
        [BindProperty]
        public UserHSCodePool userHscode { get; set; }
        public List<UserTariffExtraTax> userTariffExtraTaxes { get; set; }
        public Country country { get; set; }
        public Country Exportingcountry { get; set; }
        public Currency currency { get; set; }
        public bool HasBechMark { get; set; }
        public IList<Agency> agencies { get; set; }

        public IList<DocumentType> documents { get; set; }
        public IList<ExtraDocumentValue> documentValues { get; set; }
        public IList<string> documentCategories { get; set; }
        public List<string> documentInCategory { get; set; }
        public Dictionary<string,List<string>> dict { get; set; }
        public Sector Sector { get; set; }
        public Segment Segment { get; set; }
        public AgencyHsCode agencyHsCode { get; set; }
        public List<AgencyHsCode> AgencyHsCode { get; set; }


        public async Task<IActionResult> OnGet(Guid transactionId)
        {
            userHscode = await _mediator.Send(new GetUserHScodePoolQuery { TransactionId = transactionId });
            userTariffExtraTaxes = await _mediator.Send(new GetUserTariffListQuery { TransactionId = transactionId });
            country = _vehicleService.GetCountryName(userHscode.CountryId);
            currency = _vehicleService.GetCurrency(userHscode.CurrencyId);
            Exportingcountry = _vehicleService.GetCountryName(userHscode.ExportingCountryId);
            agencies = _generalGoodsService.GetAgency(userHscode.HsCode, userHscode.CountryId);
            Sector = _generalGoodsService.GetSector(userHscode.HsCode);
            Segment = _generalGoodsService.GetSegment(userHscode.HsCode);

            if(agencies != null)
            {
                foreach (var a in agencies)
                {
                    documents = _generalGoodsService.GetDocumentTypes(a.Id, userHscode.HsCode, userHscode.CountryId);
                    agencyHsCode = _generalGoodsService.GetAgencyHsCode(userHscode.HsCode, userHscode.CountryId);
                    // AgencyHsCode = _generalGoodsService.GetAgencyDocuments(userHscode.Id);
                    AgencyHsCode = _generalGoodsService.AgencyHsCodes(userHscode.HsCode, userHscode.CountryId);
                    if (agencyHsCode != null)
                    {
                        documentValues = _generalGoodsService.GetExtraDocumentValues(agencyHsCode.Id);
                    }
                   
                }
            }
           
            if(documents != null)
            {
               
                documentCategories = _generalGoodsService.GetDocumentCategories(userHscode.HsCode, userHscode.CountryId);

                dict = new Dictionary<string, List<string>>();
                foreach (var d in documentCategories)
                {
                    documentInCategory = _generalGoodsService.GetDocument(userHscode.HsCode, d, userHscode.CountryId);
                   // documentType = _generalGoodsService.GetDocumentType();
                    dict.Add(d, documentInCategory);
                    
                }
            }          
            if (country.CountryCode=="GH")
            {
                var mark = _generalGoodsService.GetTariffBenchmark(userHscode.HsCode); 
                if(mark.Count != 0)
                {
                    HasBechMark = true;
                }
                else
                {
                    HasBechMark = false;
                }
            }
            return Page();
        }
    }
}
