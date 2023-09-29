using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.MasterItems.Command.CreateSubscriptionType
{
  public class AddSubscriptionTypeCommand : IRequest<int>
   {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }      
        public bool IsActive { get; set; }
    }

    public class AddSubscriptionTypeCommandHandler : IRequestHandler<AddSubscriptionTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddSubscriptionTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(AddSubscriptionTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.SubscriptionType
            {
                Name = request.Name,
                Description = request.Description,               
                IsActive = request.IsActive
            };
            _context.SubscriptionTypes.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

    }
