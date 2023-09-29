using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Commands.UpdateTopResource
{
    public class UpdateTopResourceCommand : IRequest, IMapFrom<TopResource>
    {
        public string ResourceName { get; set; }
        public string LocalizationKey { get; set; }
        public int Id { get; set; }
        public int Order { get; set; }
    }

    public class UpdateTopResourceCommandHandler : IRequestHandler<UpdateTopResourceCommand>
    {

        private readonly IApplicationDbContext _context;
        public UpdateTopResourceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTopResourceCommand request, CancellationToken cancellationToken)
        {

            var entity = await _context.TopResources.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TopResource), request.Id);
            }

            entity.ResourceName = request.ResourceName;

            entity.LocalizationKey = request.LocalizationKey;

            entity.Order = request.Order;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
