using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Commands.CreateResource
{
    public class CreateResourceCommand : IRequest<int>
    {
        public int AreaId { get; set; }
        public string ResourcePage { get; set; }
        public string LocalLizationKey { get; set; }
        public int PermissionId { get; set; }
        public int Order { get; set; }
    }

    public class CreateResourceCommandHandler : IRequestHandler<CreateResourceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateResourceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateResourceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Resource
            {
                AreaId = request.AreaId,
                ResourcePage = request.ResourcePage,
                LocalLizationKey = request.LocalLizationKey,
                PermissionId = request.PermissionId,
                IsActive = true,
                Order = request.Order
            };


            _context.Resources.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
