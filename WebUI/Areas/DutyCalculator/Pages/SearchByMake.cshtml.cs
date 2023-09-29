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
using Wbc.Application.DutyCalculator.Command;
using Wbc.Application.DutyCalculator.Query;
using Wbc.Domain.Entities;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.DutyCalculator.Pages
{
    public class SearchByMakeModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<SearchByMakeModel> _stringLocalizer;

        private readonly IVehicleService _vehicleService;
        private readonly ICurrencyService _currencyService;

        public SearchByMakeModel(IMediator mediator, IStringLocalizer<SearchByMakeModel> stringLocalizer, IVehicleService vehicleService, ICurrencyService currencyService)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
            _vehicleService = vehicleService;
            _currencyService = currencyService;
        }

        [BindProperty(SupportsGet = true)]
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public SelectList MakeListdll { get; set; }
        public SelectList VehicleTypeddl { get; set; }
        public SelectList Currencylist { get; set; }
        public SelectList CountryList { get; set; }
        public string MakeName { get; set; }
        public string VehicleTypeName { get; set; }
        public string CurrencyId { get; set; }
        public string Features { get; set; }
        public int SeatingCapacity { get; set; }
        public string FuelType { get; set; }
        public string EngineCapacity { get; set; }



        [BindProperty(SupportsGet = true)]
        public CreateSearchCommand Command { get; set; }

        [BindProperty]
        public CalculatedDuty CalculatedCommand { get; set; }

        [BindProperty]
        public CreateVehiclePoolCommand cmd { get; set; }

        public void OnGet()
        {
            MakeListdll = new SelectList(_vehicleService.GetMakes(), nameof(VehicleMake.Id), nameof(VehicleMake.MakeName));
            Currencylist = new SelectList(_currencyService.GetCurrncy(), nameof(Currency.Id), nameof(Currency.Description));
            CountryList = new SelectList(_vehicleService.GetCountries().Where(x => x.CountryCode == "GH"), nameof(Country.Id), nameof(Country.CountryName));
           
        }

        public JsonResult OnGetModels()
        {
            
            return new JsonResult(_vehicleService.GetModels(MakeId));
        }

        public JsonResult OnGetVehicleTypes()
        {
           var name = _vehicleService.GetMakeName(MakeId);
            return new JsonResult(_vehicleService.GetVehicleTypes(name.MakeName));
        }

        public JsonResult OnGetFeatures(int makeId)
        {           
            return new JsonResult(_vehicleService.Getfeatures(makeId));
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                NotificationHelper.Toast(this, _stringLocalizer["ErrorTitle"], _stringLocalizer["ErrorMessageSearchNotFound"], NotificationType.Error, NotificationPosition.TopRight);
                MakeListdll = new SelectList(_vehicleService.GetMakes(), nameof(VehicleMake.Id), nameof(VehicleMake.MakeName));
                Currencylist = new SelectList(_currencyService.GetCurrncy(), nameof(Currency.Id), nameof(Currency.Description));
                CountryList = new SelectList(_vehicleService.GetCountries().Where(x=>x.CountryCode=="GH"), nameof(Country.Id), nameof(Country.CountryName));
                return Page();
            }  
            
            //TODO: Call a service to check if user has a valid subscribtion. before executing code below.



            var resultData = await _mediator.Send(new CreateSearchCommand { MakeId = Command.MakeId, ModelId = Command.ModelId, Year = Command.Year, VehicleTypeName = Command.VehicleTypeName, Features=Command.Features, SeatingCapacity=Command.SeatingCapacity, FuelType=Command.FuelType, EngineCapacity=Command.EngineCapacity,CountryId=Command.CountryId, CurrencyId=Command.CurrencyId });
            if (resultData != null)
            {

                CalculatedCommand = await _mediator.Send(new GetCalculatedDutyQuery { TransactionId = resultData.TransactionId });
                if (null != CalculatedCommand)
                {
                    NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
                    return RedirectToPage("CalculatedDutyResult", new { TransactionId = resultData.TransactionId });
                }
                
            }
            else
            {
                var searchPool = await _mediator.Send(new CreateVehiclePoolCommand { MakeId = Command.MakeId, ModelId = Command.ModelId, VehicleTypeName = Command.VehicleTypeName, Year = int.Parse(Command.Year), EngineCapacity = Command.EngineCapacity, SeatingCapacity = Command.SeatingCapacity, FuelType = Command.FuelType, SpecialFeatureName = Command.Features, CountryId = Command.CountryId, CurrencyId = Command.CurrencyId });
                return RedirectToPage("SubmittedSearchPoolResult", new { TransactionId = searchPool.TransactionId });
            }

            NotificationHelper.Toast(this, _stringLocalizer["ErrorTitle"], _stringLocalizer["ErrorMessageSearchNotFound"], NotificationType.Error, NotificationPosition.TopRight);
            MakeListdll = new SelectList(_vehicleService.GetMakes(), nameof(VehicleMake.Id), nameof(VehicleMake.MakeName));
            Currencylist = new SelectList(_currencyService.GetCurrncy(), nameof(Currency.Id), nameof(Currency.Description));
            CountryList = new SelectList(_vehicleService.GetCountries(), nameof(Country.Id), nameof(Country.CountryName));
            return Page();
        }

    }
}
