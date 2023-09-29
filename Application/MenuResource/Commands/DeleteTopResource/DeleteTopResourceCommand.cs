using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Commands.DeleteTopResource
{
    public class DeleteTopResourceCommand : IRequest, IMapFrom<TopResource>
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public string LocalizationKey { get; set; }
        public int Order { get; set; }
    }

    public class DeleteTopResourceCommandHandler : IRequestHandler<DeleteTopResourceCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public DeleteTopResourceCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime dateTime)
        {
            _context = context;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeleteTopResourceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TopResources.Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TopResource), request.Id);
            }

            entity.IsActive = false;
            entity.DeletedBy = _currentUserService.GetUserId();
            entity.DeletedOn = _dateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
