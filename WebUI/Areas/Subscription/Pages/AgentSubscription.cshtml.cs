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
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Models;
using Wbc.Application.MasterItems.Query.GetProcessRequiredDocument;
using Wbc.Application.Subscription.Command.AddSubscriber;
using Wbc.Application.Subscription.Query.GetSubscriber;
using Wbc.WebUI.Helper;

namespace Wbc.WebUI.Areas.Subscription.Pages
{
    [AllowAnonymous]
    public class AgentSubscriptionModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IStringLocalizer<AgentSubscriptionModel> _stringLocalizer;

        public AgentSubscriptionModel(IMediator mediator, IStringLocalizer<AgentSubscriptionModel> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
            Command = new AddSubscriberCommand();
        }

        [BindProperty]
        public AddSubscriberCommand Command { get; set; }
        public IList<SupportingDocumentDto> SupportingDocumentDtos { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var vm = await _mediator.Send(new GetSubscriberCommandQuery { Process = Process.AgentSubscriptionProcess });

            SupportingDocumentDtos = vm.SupportingDocumentDtos;

            Command.ProcessCode = Process.AgentSubscriptionProcess.GetAttributeStringValue();

            Command.DocumentsUploaded.AddRange(SupportingDocumentDtos.Select(x => new FileUploadModel
            {
                RequiredDocumentId = x.Id,
                FileName = x.DocumentName,
                FileExtension = x.AllowedFormats,
                FileDescription = x.DocumentDescription,
                Mandatory = x.Mandatory

            }).ToList());
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var vm = await _mediator.Send(new GetSubscriberCommandQuery { Process = Process.AgentSubscriptionProcess });

                SupportingDocumentDtos = vm.SupportingDocumentDtos;

                return Page();
            }

            var result = await _mediator.Send(Command);

            NotificationHelper.Toast(this, _stringLocalizer["SuccessTitle"], _stringLocalizer["SuccessMessage"], NotificationType.Success, NotificationPosition.TopRight);

            return RedirectToPage("/Index");
        }
    }
}
