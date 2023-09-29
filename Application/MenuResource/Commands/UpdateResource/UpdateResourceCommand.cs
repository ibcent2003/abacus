using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Commands.UpdateResource
{
    public class UpdateResourceCommand : IRequest, IMapFrom<Resource>
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string ResourcePage { get; set; }
        public string LocalLizationKey { get; set; }
        public int PermissionId { get; set; }
        public int Order { get; set; }

    }

    public class UpdateResourceCommandHandler : IRequestHandler<UpdateResourceCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateResourceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateResourceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Resources.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Resource), request.Id);
            }

            entity.ResourcePage = request.ResourcePage;
            entity.PermissionId = request.PermissionId;
            entity.AreaId = request.AreaId;
            entity.LocalLizationKey = request.LocalLizationKey;
            entity.Order = request.Order;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
