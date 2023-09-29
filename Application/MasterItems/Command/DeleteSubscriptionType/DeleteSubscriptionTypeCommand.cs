using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;

namespace Wbc.Application.MasterItems.Command.DeleteSubscriptionType
{
   public class DeleteSubscriptionTypeCommand : IRequest, IMapFrom<Domain.Entities.Permission>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public bool IsActive { get; set; }
    }
    public class DeleteSubscriptionTypeCommandHandler : IRequestHandler<DeleteSubscriptionTypeCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;
        private readonly IDateTime _dateTime;

        public DeleteSubscriptionTypeCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
        {
            _context = context;
            _userService = userService;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeleteSubscriptionTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SubscriptionTypes.Where(l => l.Id == request.Id)

                 .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.SubscriptionType), request.Id);
            }

            entity.IsActive = false;
            entity.DeletedBy =  _userService.GetUserId();
            entity.DeletedOn = _dateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }

}
