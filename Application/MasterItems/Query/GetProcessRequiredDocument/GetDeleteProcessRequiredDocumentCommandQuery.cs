using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.DeleteProcessRequiredDocument;

namespace Wbc.Application.MasterItems.Query.GetProcessRequiredDocument
{
    public class GetDeleteProcessRequiredDocumentCommandQuery : IRequest<DeleteProcessRequiredDocumentCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteProcessRequiredDocumentCommandQueryHandler : IRequestHandler<GetDeleteProcessRequiredDocumentCommandQuery, DeleteProcessRequiredDocumentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetDeleteProcessRequiredDocumentCommandQueryHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<DeleteProcessRequiredDocumentCommand> Handle(GetDeleteProcessRequiredDocumentCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProcessRequiredDocuments.Include(x => x.Process).Include(x => x.RequiredDocument).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin) && entity.SubscriberId.HasValue) throw new NotFoundException(nameof(entity), request.Id);

            if (!_currentUserService.UserHasRole(Roles.TradeHubAdmin))
            {
                var orgId = _currentUserService.GetUserOrganisationId();

                var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.ParentId == orgId, cancellationToken);

                if (entity.SubscriberId != subscriber.Id) throw new NotFoundException(nameof(entity), request.Id);
            }

            var processRequiredDocumentDto = _mapper.Map<SupportingDocumentDto>(entity);

            return _mapper.Map<DeleteProcessRequiredDocumentCommand>(processRequiredDocumentDto);
        }

    }
}
