using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.UpdateDocumentCategory
{
    public class UpdateDocumentCategoryCommand : IRequest, IMapFrom<DocumentCategory>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateDocumentCategoryCommandHandler : IRequestHandler<UpdateDocumentCategoryCommand>
    {
        private readonly IApplicationDbContext _context;


        public UpdateDocumentCategoryCommandHandler(IApplicationDbContext context, AdminConfiguration adminConfiguration)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateDocumentCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DocumentCategories.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Process), request.Id);
            }

            entity.CategoryName = request.CategoryName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
