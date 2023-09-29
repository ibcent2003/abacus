using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ValidateOrgEmailModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<ValidateOrgEmailModel> _stringLocalizer;

        public ValidateOrgEmailModel(IMediator mediator, IStringLocalizer<ValidateOrgEmailModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<JsonResult> OnGet(string valueToValidate)
        {

            if (string.IsNullOrEmpty(valueToValidate)) return new JsonResult(new
            {
                IsExist = true,
                Message = _stringLocalizer["NullErrorMessage"]
            });

            var result = await _mediator.Send(new ValidateSubscriberEmailQuery { EmailAddress = valueToValidate });

            return new JsonResult(new
            {
                IsExist = result,
                Message = result ? _stringLocalizer["OrganisationEmailExistError"] : ""
            });
        }


    }
}
