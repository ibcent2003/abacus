using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Command.CreateRequiredDocument;

namespace Wbc.Application.MasterItems.Query.GetRequiredDocument
{
    public class GetAddRequiredDocumentCommandQuery : IRequest<AddRequiredDocumentCommand>
    {
    }

    public class GetAddRequiredDocumentCommandQueryHandler : IRequestHandler<GetAddRequiredDocumentCommandQuery, AddRequiredDocumentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public GetAddRequiredDocumentCommandQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<AddRequiredDocumentCommand> Handle(GetAddRequiredDocumentCommandQuery request, CancellationToken cancellationToken)
        {

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin)) return new AddRequiredDocumentCommand();

            var orgId = _currentUserService.GetUserOrganisationId();

            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.ParentId == orgId, cancellationToken);

            return new AddRequiredDocumentCommand
            {
                SubscriberId = subscriber.Id,
                IsInternalUse = false
            };



        }
    }
}
