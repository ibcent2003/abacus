using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Commands.CreateTopResource
{
    public class CreateTopResourceCommand : IRequest<int>
    {
        public string ResourceName { get; set; }
        public string LocalizationKey { get; set; }
        public int Order { get; set; }

    }

    public class CreateTopResourceCommandHandler : IRequestHandler<CreateTopResourceCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateTopResourceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTopResourceCommand request, CancellationToken cancellationToken)
        {

            var entity = new TopResource
            {
                ResourceName = request.ResourceName,
                LocalizationKey = request.LocalizationKey,
                IsActive = true,
                Order = request.Order
            };

            _context.TopResources.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;


        }
    }
}
