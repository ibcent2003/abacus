using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Workflow.Commands.ExecuteApprovalCommand
{
    public class ExecuteApprovalCommand : IRequest<bool>
    {
        public string CommandName { get; set; }
        public string Comment { get; set; }
        public Guid ProcessId { get; set; }

    }

    public class ExecuteApprovalCommandHandler : IRequestHandler<ExecuteApprovalCommand, bool>
    {
        private readonly IWorkflowService _workflowService;
        private readonly ICurrentUserService _currentUserService;

        public ExecuteApprovalCommandHandler(IWorkflowService workflowService, ICurrentUserService currentUserService)
        {
            _workflowService = workflowService;
            _currentUserService = currentUserService;
        }

        public async Task<bool> Handle(ExecuteApprovalCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();

            return await _workflowService.ExecuteCommandAsync(request.ProcessId, request.CommandName, userId, request.Comment, cancellationToken);
        }
    }
}
