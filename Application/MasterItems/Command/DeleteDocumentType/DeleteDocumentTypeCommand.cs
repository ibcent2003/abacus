using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.DeleteDocumentType
{
    public class DeleteDocumentTypeCommand : IRequest, IMapFrom<DocumentType>
    {
        public int Id { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentTypeName { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteDocumentTypeCommandHandler : IRequestHandler<DeleteDocumentTypeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;
        private readonly IDateTime _dateTime;

        public DeleteDocumentTypeCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
        {
            _context = context;
            _userService = userService;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DocumentTypes.Where(l => l.Id == request.Id)

                 .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(DocumentType), request.Id);
            }

            entity.IsActive = false;
            entity.DeletedBy = _userService.GetUserId();
            entity.DeletedOn = _dateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
