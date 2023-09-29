using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;

namespace Wbc.Application.MasterItems.Command.DeleteRequiredDocument
{
    public class DeleteRequiredDocumentCommand : IRequest, IMapFrom<Domain.Entities.RequiredDocument>
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentFormatString { get; set; }
        public string MaximumSize { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public class DeleteRequiredDocumentCommandHandler : IRequestHandler<DeleteRequiredDocumentCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;
        private readonly IDateTime _dateTime;

        public DeleteRequiredDocumentCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
        {
            _context = context;
            _userService = userService;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeleteRequiredDocumentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RequiredDocuments.Where(l => l.Id == request.Id)

                 .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.RequiredDocument), request.Id);
            }

            entity.IsActive = false;
            entity.DeletedBy = _userService.GetUserId();
            entity.DeletedOn = _dateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
