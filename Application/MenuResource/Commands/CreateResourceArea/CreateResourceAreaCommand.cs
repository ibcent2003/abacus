using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Commands.CreateResourceArea
{
    public class CreateResourceAreaCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string AreaName { get; set; }
        public string LocalizationKey { get; set; }
        public string IconUrl { get; set; }
        public int Order { get; set; }

    }

    public class CreateResourceAreaCommandHandler : IRequestHandler<CreateResourceAreaCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateResourceAreaCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateResourceAreaCommand request, CancellationToken cancellationToken)
        {
            var entity = new ResourceArea
            {
                ParentId = request.ParentId,
                AreaName = request.AreaName,
                LocalizationKey = request.LocalizationKey,
                IconUrl = request.IconUrl,
                IsActive = true,
                Order = request.Order
            };

            _context.ResourceAreas.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
