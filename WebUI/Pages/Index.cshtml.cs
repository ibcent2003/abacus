using Application.Registration.GetGuestUser;
using IdentityModel.Client;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.GeneralGoods.Command.CreateGeneralGoodsSearch;
using Wbc.Application.GeneralGoods.Query;
using Wbc.Application.Registration.Command.AddGuestUser;
using Wbc.Domain.Entities;
using Wbc.WebUI.Helper;


namespace Wbc.WebUI.Pages
{

    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //private readonly IStringLocalizer<IndexModel> _localizer;

        private readonly IStringLocalizer<IndexModel> _stringLocalizer;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMediator _mediator;
        private readonly ICurrencyService _currencyService;
        private readonly IVehicleService _vehicleService;
      //  private readonly ICurrencyService _currencyService;
        private readonly IGeneralGoodsService _generalGoodsService;

        public IndexModel(ILogger<IndexModel> logger, IStringLocalizer<IndexModel> stringLocalizer, ICurrentUserService currentUserService, IMediator mediator, IVehicleService vehicleService, IGeneralGoodsService generalGoodsService, ICurrencyService currencyService)
        {
            _logger = logger;
            _stringLocalizer = stringLocalizer;
            _currentUserService = currentUserService;
            _mediator = mediator;
            _vehicleService = vehicleService;
            _generalGoodsService = generalGoodsService;
            _currencyService = currencyService;
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
        public string Ipaddress { get; set; }
        [BindProperty]
        public AddGuestUserCommand UserCommand { get; set; }
        public GuestUser GuestUser { get; set; }
        public string guest_Cookie { get; set; }
        
        public UserTariffExtraTax UserTariffExtraTax { get; set; }



        public async Task<IActionResult> OnGet(string abacus_import, string abacus_product, decimal abacus_cost)
        {



            //if (Request.Cookies["guest"] == null)
            //{
               
            //}

            if (Request.Cookies["guest"] == null)
            {
                string cookId = Guid.NewGuid().ToString();
                HttpContext.Response.Cookies.Append("guest", cookId.ToString());
                guest_Cookie =  cookId.ToString();
                var IPData = await _mediator.Send(new AddGuestUserCommand { Ip = cookId.ToString(), AccessDate = DateTime.UtcNow, NoOfUse = 5 });
                GuestUser = _vehicleService.GetGuestUser(cookId.ToString());
            }
            else
            {
                var firstRequest = HttpContext.Request.Cookies["guest"];
                guest_Cookie =  firstRequest.ToString();
                GuestUser = _vehicleService.GetGuestUser(guest_Cookie);
            }

            if (abacus_import != null && abacus_product != null && abacus_cost != 0)
            {
                Currencylist = new SelectList(_currencyService.GetCurrncy(), nameof(Currency.Id), nameof(Currency.Description));
                CountryList = new SelectList(_vehicleService.GetCountries().Where(x => x.CountryName == abacus_import), nameof(Country.Id), nameof(Country.CountryName));
                ExportingCountryList = new SelectList(_vehicleService.GetExportingCountries(), nameof(Country.Id), nameof(Country.CountryName));
                Abacus_import = abacus_import;
                Command.FOB = abacus_cost;
                Command.Keyword = abacus_product;
            }
         
            Currencylist = new SelectList(_currencyService.GetCurrncy(), nameof(Currency.Id), nameof(Currency.Description));
            CountryList = new SelectList(_vehicleService.GetCountries(), nameof(Country.Id), nameof(Country.CountryName));
            ExportingCountryList = new SelectList(_vehicleService.GetExportingCountries(), nameof(Country.Id), nameof(Country.CountryName));


            return Page();

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
         
            var GetGuest = _vehicleService.GetGuestUser(HttpContext.Request.Cookies["guest"]);
            if(GetGuest.NoOfUse == 0)
            {
                return RedirectToPage("FreeTrailTerminated");
            }

            //TODO: Call a service to check if user has a valid subscribtion. before executing code below.
            if (abacus_import != null && abacus_product != null && abacus_cost != 0)
            {
                GetCountryName = _vehicleService.GetCountry(abacus_import);
                var resultData = await _mediator.Send(new TrialCommand { HsCode = Command.HsCode, FOB = Command.FOB, Freight = Command.Freight, Insurance = Command.Insurance, CountryId = GetCountryName.Id, CurrencyId = Command.CurrencyId, ExportingCountryId = Command.ExportingCountryId, Keyword = Command.Keyword, ContainerSize = Command.ContainerSize });
                if (resultData != null)
                {
                    NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
                    return RedirectToPage("GeneralGoodDutyResult", new { TransactionId = resultData.TransactionId });

                }
            }
            else
            {
                var resultData = await _mediator.Send(new TrialCommand { GuestCookie= GetGuest.Ip,  HsCode = Command.HsCode, FOB = Command.FOB, Freight = Command.Freight, Insurance = Command.Insurance, CountryId = Command.CountryId, CurrencyId = Command.CurrencyId, ExportingCountryId = Command.ExportingCountryId, Keyword = Command.Keyword, ContainerSize = Command.ContainerSize });
                if (resultData != null)
                {
                   
                    NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
                    return RedirectToPage("GeneralGoodDutyGuestResult", new { TransactionId = resultData.TransactionId, Id = resultData.UserId });

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
