using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.CreateDocumentCategory
{
   public class AddDocumentCategoryCommand : IRequest<int>
    {
            
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }

    public class AddDocumentCategoryCommandHandler : IRequestHandler<AddDocumentCategoryCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddDocumentCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddDocumentCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new DocumentCategory
            {
                CategoryName = request.CategoryName,
                IsActive = true
            };

            _context.DocumentCategories.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
