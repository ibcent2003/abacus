using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Commands.UpdateResourceArea
{
    public class UpdateResourceAreaCommand : IRequest, IMapFrom<ResourceArea>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string AreaName { get; set; }
        public string LocalizationKey { get; set; }
        public string IconUrl { get; set; }
        public int Order { get; set; }


    }

    public class UpdateResourceAreaCommandHandler : IRequestHandler<UpdateResourceAreaCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateResourceAreaCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateResourceAreaCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ResourceAreas.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Resource), request.Id);
            }

            entity.AreaName = request.AreaName;
            entity.ParentId = request.ParentId;
            entity.IconUrl = request.IconUrl;
            entity.Order = request.Order;
            entity.LocalizationKey = request.LocalizationKey;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
