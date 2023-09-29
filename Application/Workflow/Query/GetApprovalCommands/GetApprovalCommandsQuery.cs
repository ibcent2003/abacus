using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Workflow.Query.GetApprovalCommands
{
    public class GetApprovalCommandsQuery : IRequest<ApprovalCommandsVm>
    {
        public int DocumentId { get; set; }
    }

    public class GetApprovalCommandsQueryHandler : IRequestHandler<GetApprovalCommandsQuery, ApprovalCommandsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IWorkflowService _workflowService;
        private readonly ICurrentUserService _currentUserService;


        public GetApprovalCommandsQueryHandler(IApplicationDbContext dbContext, IMapper mapper, IWorkflowService workflowService, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _workflowService = workflowService;
            _currentUserService = currentUserService;
        }

        public async Task<ApprovalCommandsVm> Handle(GetApprovalCommandsQuery request, CancellationToken cancellationToken)
        {
            var document = await _dbContext.Documents.FirstOrDefaultAsync(x => x.Id == request.DocumentId, cancellationToken);
            var userId = _currentUserService.GetUserId();
            var histories = await _dbContext.DocumentTransitionHistories.Where(x => x.DocumentId == request.DocumentId).ProjectTo<DocumentTransitionHistoryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var availablecommands = await _workflowService.GetAllAvailableCommandsAsync(document.WorkflowProcessId, userId);
            var currentState = await _workflowService.GetCurrentStateAsync(document.WorkflowProcessId);
            return new ApprovalCommandsVm { DocumentTransitionHistoryDtos = histories, Commands = availablecommands, CurrentState = currentState, ProcessId = document.WorkflowProcessId, DocumentSource = $"{document.DocumentSource}/{request.DocumentId}" };
        }
    }
}
