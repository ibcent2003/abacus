using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Command.CreateRequiredDocument
{
    public class AddRequiredDocumentCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentFormatString { get; set; }
        public string MaximumSize { get; set; }
        public bool IsInternalUse { get; set; }
        public int? SubscriberId { get; set; }
    }

    public class AddRequiredDocumentCommandHandler : IRequestHandler<AddRequiredDocumentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public AddRequiredDocumentCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<int> Handle(AddRequiredDocumentCommand request, CancellationToken cancellationToken)
        {

            var entity = new RequiredDocument
            {
                DocumentName = request.DocumentName,
                SubscriberId = request.SubscriberId,
                DocumentDescription = request.DocumentDescription,
                DocumentFormatString = request.DocumentFormatString,
                MaximumSize = request.MaximumSize,
                IsActive = true,
                IsInternalUse = request.IsInternalUse
            };

            if (!_currentUserService.UserHasRole(Roles.TradeHubAdmin)) entity.IsInternalUse = false;

            _context.RequiredDocuments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
