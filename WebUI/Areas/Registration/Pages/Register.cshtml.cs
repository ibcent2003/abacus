using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Registration.Command.AddRegister;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Registration.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<RegisterModel> _stringLocalizer;
        private readonly ICurrentUserService _currentUserService;


        public RegisterModel(IMediator mediator, IStringLocalizer<RegisterModel> stringLocalizer, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
            _currentUserService = currentUserService;
        }
        [BindProperty]
        public AddRegisterCommand Command { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var res = await _mediator.Send(Command);
            if (res == 1)
            {
                NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);
                return RedirectToPage("/SuccessRegistration", new { area = "Registration" });
            }

            NotificationHelper.Toast(this, _stringLocalizer["ErrorTitle"], _stringLocalizer["ErrorMessage"], NotificationType.Error, NotificationPosition.TopRight);
            return Page();
        }
    }
}
