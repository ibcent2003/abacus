using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Subscription.Query.GetSubscriber;

namespace Wbc.WebUI.Areas.Subscription.Pages
{
    [AllowAnonymous]
    public class ValidateAdminEmailModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<ValidateAdminEmailModel> _stringLocalizer;

        public ValidateAdminEmailModel(IMediator mediator, IStringLocalizer<ValidateAdminEmailModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<JsonResult> OnGetAsync(string valueToValidate)
        {
            var result = await _mediator.Send(new ValidateSubscriberAdminEmailQuery { EmailAddress = valueToValidate });

            return new JsonResult(new
            {
                IsExist = result,
                Message = result ? _stringLocalizer["AdminEmailExistError"] : ""
            });
        }
    }
}
