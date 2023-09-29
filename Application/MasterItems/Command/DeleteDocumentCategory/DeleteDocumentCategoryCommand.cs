using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.DeleteDocumentCategory
{
    public class DeleteDocumentCategoryCommand : IRequest, IMapFrom<DocumentCategory>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteDocumentCategoryCommandHandler : IRequestHandler<DeleteDocumentCategoryCommand>
    {

        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _datetime;

        public DeleteDocumentCategoryCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime datetime)
        {
            _context = context;
            _currentUserService = currentUserService;
            _datetime = datetime;
        }

        public async Task<Unit> Handle(DeleteDocumentCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DocumentCategories.Where(l => l.Id == request.Id).SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(DocumentCategory), request.Id);
            }

            entity.IsActive = false;
            entity.DeletedBy = _currentUserService.GetUserId();
            entity.DeletedOn = _datetime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
