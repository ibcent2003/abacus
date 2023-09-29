using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.TariffManager.Command.CreateSearch;
using Wbc.Application.TariffManager.Query.GetGlobalTariff;
using Wbc.Domain.Entities;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.TariffManager.Pages
{
    public class SearchTariffModel : PageModel
    {

        private readonly IMediator _mediator;
        private readonly IStringLocalizer<SearchTariffModel> _stringLocalizer;
        private readonly IGeneralGoodsService _generalGoodsService;
        private readonly IVehicleService _vehicleService;
        private readonly ICurrencyService _currencyService;


        public SearchTariffModel(IMediator mediator, IStringLocalizer<SearchTariffModel> stringLocalizer, IVehicleService vehicleService, ICurrencyService currencyService, IGeneralGoodsService generalGoodsService)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
            _vehicleService = vehicleService;
            _currencyService = currencyService;
            _generalGoodsService = generalGoodsService;

        }


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
        public Dictionary<string, List<string>> dict { get; set; }
        public string GetV { get; set; }


        public SelectList CountryList { get; set; }

        [BindProperty(SupportsGet = true)]
         public CreateHSCodeSearchCommand Command { get; set; }
        [BindProperty]
        public TarrifVm tarrifVm { get; set; }

        public void OnGet()
        {
            CountryList = new SelectList(_vehicleService.GetCountries(), nameof(Country.Id), nameof(Country.CountryName));
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Toast(this, _stringLocalizer["ErrorTitle"], _stringLocalizer["ErrorMessageSearchNotFound"], NotificationType.Error, NotificationPosition.TopRight);
                CountryList = new SelectList(_vehicleService.GetCountries(), nameof(Country.Id), nameof(Country.CountryName));

                return RedirectToPage("/SearchTariff", new { area = "TariffManager" });
            }
            tarrifVm = await _mediator.Send(new CreateHSCodeSearchCommand { HScode = Command.HScode, CountryId = Command.CountryId });
            if (tarrifVm != null)
            {

                agencies = _generalGoodsService.GetAgencyHsCodes(Command.HScode, Command.CountryId);
                if (agencies != null)
                {
                    foreach (var a in agencies)
                    {
                        documents = _generalGoodsService.GetDocumentTypes(a.Id, Command.HScode, Command.CountryId);
                    }
                }


                if (documents != null)
                {
                    foreach (var d in documents)
                    {
                        documentValues = _generalGoodsService.GetExtraDocumentValues(d.Id);
                    }
                    documentCategories = _generalGoodsService.GetDocumentCategories(Command.HScode, Command.CountryId);

                    dict = new Dictionary<string, List<string>>();
                    foreach (var d in documentCategories)
                    {
                        documentInCategory = _generalGoodsService.GetDocument(Command.HScode, d, Command.CountryId);
                        dict.Add(d, documentInCategory);

                    }
                }



                NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
                CountryList = new SelectList(_vehicleService.GetCountries(), nameof(Country.Id), nameof(Country.CountryName));

                return Page();
            }
           

            NotificationHelper.Toast(this, _stringLocalizer["ErrorTitle"], _stringLocalizer["ErrorMessageSearchNotFound"], NotificationType.Error, NotificationPosition.TopRight);
            CountryList = new SelectList(_vehicleService.GetCountries(), nameof(Country.Id), nameof(Country.CountryName));
            return Page();
        }


       
    }
}
