using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.CreateDocumentType
{
   public class AddDocumentTypeCommand : IRequest<int>
    {
         public int Id { get; set; }
         public string DocumentTypeCode { get; set; }
         public string DocumentTypeName { get; set; }
        public string DocumentTag { get; set; }
         public bool IsActive { get; set; }
    }

    public class AddDocumentTypeCommandHandler : IRequestHandler<AddDocumentTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddDocumentTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = new DocumentType
            {
                DocumentTypeName = request.DocumentTypeName,
                DocumentTypeCode = request.DocumentTypeCode,
                DocumentTag = request.DocumentTag,
                IsActive = true
            };

            _context.DocumentTypes.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
