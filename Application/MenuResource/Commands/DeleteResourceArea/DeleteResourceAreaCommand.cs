using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MenuResource.Query.GetResourceArea;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Commands.DeleteResourceArea
{
    public class DeleteResourceAreaCommand : IRequest, IMapFrom<ResourceAreaDto>
    {
        public int Id { get; set; }
        public string ParentName { get; set; }
        public string AreaName { get; set; }
        public string LocalizationKey { get; set; }
        public int Order { get; set; }
        public string IconUrl { get; set; }

    }

    public class DeleteResourceAreaCommandHandler : IRequestHandler<DeleteResourceAreaCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;
        private readonly IDateTime _dateTime;

        public DeleteResourceAreaCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
        {
            _context = context;
            _userService = userService;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeleteResourceAreaCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ResourceAreas.Where(l => l.Id == request.Id).SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ResourceArea), request.Id);
            }

            entity.IsActive = false;
            entity.DeletedBy = _userService.GetUserId();
            entity.DeletedOn = _dateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
