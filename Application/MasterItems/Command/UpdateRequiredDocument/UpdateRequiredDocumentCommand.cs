using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;

namespace Wbc.Application.MasterItems.Command.UpdateRequiredDocument
{
    public class UpdateRequiredDocumentCommand : IRequest, IMapFrom<Domain.Entities.RequiredDocument>
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentFormatString { get; set; }
        public string MaximumSize { get; set; }
        public bool IsInternalUse { get; set; }
        public int SubscriberId { get; set; }
    }

    public class UpdateRequiredDocumentCommandHandler : IRequestHandler<UpdateRequiredDocumentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public UpdateRequiredDocumentCommandHandler(IApplicationDbContext context, AdminConfiguration adminConfiguration, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(UpdateRequiredDocumentCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.RequiredDocuments.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(MasterItems), request.Id);
            }

            entity.DocumentName = request.DocumentName;
            entity.DocumentDescription = request.DocumentDescription;
            entity.DocumentFormatString = request.DocumentFormatString;
            entity.MaximumSize = request.MaximumSize;
            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin)) entity.IsInternalUse = request.IsInternalUse;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
