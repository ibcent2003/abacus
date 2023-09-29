using System.Threading.Tasks;
using Application.MasterItems.Query.GetAgency;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.WebUI.Filter;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.MasterItems.Pages
{
    [AuthorizePolicy(Policies.CanAddAgency)]
    public class AddAgencyModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AddAgencyModel> _stringLocalizer;

        public AddAgencyModel(IMediator mediator, IStringLocalizer<AddAgencyModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }
        [BindProperty]
       public AgencyVm AgencyVm { get;set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            //if(AgencyVm.LogoUploaded != null)
            //{
            //    AgencyVm.LogoUploaded.Add()
        
            //}

            var dummy = await _mediator.Send(AgencyVm);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("ListAgency");
        }
    }
}
