using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Query.GetProcess;
using Wbc.Application.MasterItems.Query.GetRequiredDocument;

namespace Wbc.Application.MasterItems.Query.GetProcessRequiredDocument
{
    public class GetAddProcessRequiredDocumentQuery : IRequest<ProcessRequiredDocumentVm>
    {
        public int ProcessId { get; set; }
    }

    public class GetAddProcessRequiredDocumentQueryHandler : IRequestHandler<GetAddProcessRequiredDocumentQuery, ProcessRequiredDocumentVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISsoService _ssoService;
        private readonly ICurrentUserService _currentUserService;

        public GetAddProcessRequiredDocumentQueryHandler(IApplicationDbContext context, IMapper mapper, ISsoService ssoService, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _ssoService = ssoService;
            _currentUserService = currentUserService;
        }

        public async Task<ProcessRequiredDocumentVm> Handle(GetAddProcessRequiredDocumentQuery request, CancellationToken cancellationToken)
        {
            var process = await _context.Processes.FindAsync(request.ProcessId);

            var vm = new ProcessRequiredDocumentVm
            {
                ProcessDto = _mapper.Map<ProcessDto>(process),

                RequiredDocuments = await _context.RequiredDocuments.ProjectTo<RequiredDocumentDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin)) return vm;

            var orgId = _currentUserService.GetUserOrganisationId();

            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.ParentId == orgId, cancellationToken);

            vm.SubscriberId = subscriber.Id;

            return vm;
        }
    }
}
