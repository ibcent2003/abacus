using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wbc.Application.Common.Enums;
using Wbc.Application.Workflow.Query.GetApprovalCommands;
using Wbc.WebUI.Filter;

namespace Wbc.WebUI.ViewComponents
{
    [AuthorizePolicy(Policies.CanListApprovalInbox)]
    public class ApprovalHandlerViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ApprovalHandlerViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IViewComponentResult Invoke(int documentId)
        {
            var vm = _mediator.Send(new GetApprovalCommandsQuery { DocumentId = documentId }).Result;

            return View(vm);
        }
    }
}
