using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.Common.Enums;
using Wbc.Application.MasterItems.Query.GetProcessSubmittedDocument;
using Wbc.Application.Subscription.Query.GetSubscriber;
using Wbc.WebUI.Filter;

namespace Wbc.WebUI.Areas.Subscription.Pages
{
    [AuthorizePolicy(Policies.CanApproveChamberRegistration)]
    public class RegistrationApprovalDetailsModel : PageModel
    {
        private readonly IMediator _mediator;
        public RegistrationApprovalDetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public SubscriptionDto Command { get; set; }
        public IList<ProcessSubmittedDocumentDto> SubmittedDocumentDtos { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var vm = await _mediator.Send(new GetSubscriberDetailsQuery { SubscriberId = id });

            Command = vm.SubscriptionDto;
            SubmittedDocumentDtos = vm.SubmittedDocuments;

            return Page();
        }
    }
}
