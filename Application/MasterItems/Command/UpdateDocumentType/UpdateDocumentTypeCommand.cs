using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.UpdateDocumentType
{
    public class UpdateDocumentTypeCommand : IRequest, IMapFrom<DocumentType>
    {
        public int Id { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentTypeName { get; set; }

    }

    public class UpdateDocumentTypeCommandHandler : IRequestHandler<UpdateDocumentTypeCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateDocumentTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DocumentTypes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(DocumentType), request.Id);
            }

            entity.DocumentTypeName = request.DocumentTypeName;
            entity.DocumentTypeCode = request.DocumentTypeCode;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
