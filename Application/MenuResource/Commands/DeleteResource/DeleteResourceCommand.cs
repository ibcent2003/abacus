using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Application.MenuResource.Query.GetResource;
using Wbc.Domain.Entities;

namespace Wbc.Application.MenuResource.Commands.DeleteResource
{
    public class DeleteResourceCommand : IRequest, IMapFrom<ResourceDto>
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public string PersmissionDescription { get; set; }
        public string ResourcePage { get; set; }
        public int Order { get; set; }
        public string LocalLizationKey { get; set; }

    }

    public class DeleteResourceCommandHandler : IRequestHandler<DeleteResourceCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;
        private readonly IDateTime _dateTime;

        public DeleteResourceCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
        {
            _context = context;
            _userService = userService;
            _dateTime = dateTime;
        }


        public async Task<Unit> Handle(DeleteResourceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Resources.Where(l => l.Id == request.Id)

                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Resource), request.Id);
            }

            entity.IsActive = false;
            entity.DeletedBy = _userService.GetUserId();
            entity.DeletedOn = _dateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
