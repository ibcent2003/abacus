using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.GeneralGoods.Command.CreateGeneralGoodsSearch;
using Wbc.Application.GeneralGoods.Query;
using Wbc.Domain.Entities;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.GeneralGoods.Pages
{
    [AllowAnonymous]
    public class GeneralGoodsDutyModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<GeneralGoodsDutyModel> _stringLocalizer;
        private readonly IVehicleService _vehicleService;
        private readonly ICurrencyService _currencyService;
        private readonly IGeneralGoodsService _generalGoodsService;
        private readonly IActionContextAccessor _accessor;

        public GeneralGoodsDutyModel(IMediator mediator, IStringLocalizer<GeneralGoodsDutyModel> stringLocalizer, IVehicleService vehicleService, ICurrencyService currencyService, IGeneralGoodsService generalGoodsService, IActionContextAccessor accessor)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
            _vehicleService = vehicleService;
            _currencyService = currencyService;
            _generalGoodsService = generalGoodsService;
            _accessor = accessor;
        }

        public SelectList Currencylist { get; set; }

        public SelectList CountryList { get; set; }
        public SelectList ExportingCountryList { get; set; }

        [BindProperty(SupportsGet = true)]
        public CreateGeneralGoodsSearchCommand Command { get; set; }
        public GetUserHScodePoolQuery DutyQuery { get; set; }
        public List<string> hSCodePools { get; set; }
        public Country GetCountryName { get; set; }
        public string Abacus_import { get; set; }
        public string ipAddress { get; set; }
        //public decimal abacus_cost { get; set; }


        public void OnGet(string abacus_import, string abacus_product, decimal abacus_cost)
        {
          

            if (abacus_import != null && abacus_product != null && abacus_cost != 0)
            {
                Currencylist = new SelectList(_currencyService.GetCurrncy(), nameof(Currency.Id), nameof(Currency.Description));             
                CountryList = new SelectList(_vehicleService.GetCountries().Where(x => x.CountryName == abacus_import), nameof(Country.Id), nameof(Country.CountryName));
                ExportingCountryList = new SelectList(_vehicleService.GetExportingCountries(), nameof(Country.Id), nameof(Country.CountryName));
                Abacus_import = abacus_import;
                Command.FOB = abacus_cost;
                Command.Keyword = abacus_product;
            }
            else
            {
                Currencylist = new SelectList(_currencyService.GetCurrncy(), nameof(Currency.Id), nameof(Currency.Description));
                CountryList = new SelectList(_vehicleService.GetCountries(), nameof(Country.Id), nameof(Country.CountryName));
                ExportingCountryList = new SelectList(_vehicleService.GetExportingCountries(), nameof(Country.Id), nameof(Country.CountryName));
            }


          


        }

        public async Task<IActionResult> OnPost(string abacus_import, string abacus_product, decimal abacus_cost)
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Toast(this, _stringLocalizer["ErrorTitle"], _stringLocalizer["ErrorMessageSearchNotFound"], NotificationType.Error, NotificationPosition.TopRight);

                if (abacus_import != null && abacus_product != null && abacus_cost != 0)
                {
                    CountryList = new SelectList(_vehicleService.GetCountries().Where(x => x.CountryName == abacus_import), nameof(Country.Id), nameof(Country.CountryName));
                }
                else
                {
                    CountryList = new SelectList(_vehicleService.GetCountries(), nameof(Country.Id), nameof(Country.CountryName));
                }
                Currencylist = new SelectList(_currencyService.GetCurrncy(), nameof(Currency.Id), nameof(Currency.Description));
                ExportingCountryList = new SelectList(_vehicleService.GetExportingCountries(), nameof(Country.Id), nameof(Country.CountryName));
                return Page();
            }

            //TODO: Call a service to check if user has a valid subscribtion. before executing code below.
            if (abacus_import != null && abacus_product != null && abacus_cost != 0)
            {
                GetCountryName = _vehicleService.GetCountry(abacus_import);
                var resultData = await _mediator.Send(new CreateGeneralGoodsSearchCommand { HsCode = Command.HsCode, FOB = Command.FOB, Freight = Command.Freight, Insurance = Command.Insurance, CountryId = GetCountryName.Id, CurrencyId = Command.CurrencyId, ExportingCountryId = Command.ExportingCountryId, Keyword = Command.Keyword, ContainerSize = Command.ContainerSize });
                if (resultData != null)
                {
                    NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
                    return RedirectToPage("GeneralGoodDutyResult", new { TransactionId = resultData.TransactionId });

                }
            }
            else
            {
                var resultData = await _mediator.Send(new CreateGeneralGoodsSearchCommand { HsCode = Command.HsCode, FOB = Command.FOB, Freight = Command.Freight, Insurance = Command.Insurance, CountryId = Command.CountryId, CurrencyId = Command.CurrencyId, ExportingCountryId = Command.ExportingCountryId, Keyword = Command.Keyword, ContainerSize = Command.ContainerSize });
                if (resultData != null)
                {
                    NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
                    return RedirectToPage("GeneralGoodDutyResult", new { TransactionId = resultData.TransactionId });

                }
            }


            NotificationHelper.Toast(this, _stringLocalizer["ErrorTitle"], _stringLocalizer["ErrorMessageSearchNotFound"], NotificationType.Error, NotificationPosition.TopRight);
            if (abacus_import != null && abacus_product != null && abacus_cost != 0)
            {
                CountryList = new SelectList(_vehicleService.GetCountries().Where(x => x.CountryName == abacus_import), nameof(Country.Id), nameof(Country.CountryName));
            }
            else
            {
                CountryList = new SelectList(_vehicleService.GetCountries(), nameof(Country.Id), nameof(Country.CountryName));
            }
            Currencylist = new SelectList(_currencyService.GetCurrncy(), nameof(Currency.Id), nameof(Currency.Description));
            //CountryList = new SelectList(_vehicleService.GetCountries(), nameof(Country.Id), nameof(Country.CountryName));
            ExportingCountryList = new SelectList(_vehicleService.GetExportingCountries(), nameof(Country.Id), nameof(Country.CountryName));
            return Page();
        }

        public IActionResult OnGetSearchHscode(string term)
        {
            hSCodePools = _generalGoodsService.GetHsCodeList(term);
            return new JsonResult(hSCodePools);
        }


    }
    }
