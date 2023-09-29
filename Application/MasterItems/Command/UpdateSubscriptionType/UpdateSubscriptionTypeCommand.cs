using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Command.UpdateSubscriptionType
{
   public class UpdateSubscriptionTypeCommand : IRequest, IMapFrom<SubscriptionType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }       
        public bool IsActive { get; set; }
    }

    public class UpdateSubscriptionTypeCommandHandler : IRequestHandler<UpdateSubscriptionTypeCommand>
    {

        private readonly IApplicationDbContext _context;
        public UpdateSubscriptionTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Unit> Handle(UpdateSubscriptionTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SubscriptionTypes.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SubscriptionType), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;           
            entity.IsActive = request.IsActive;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
