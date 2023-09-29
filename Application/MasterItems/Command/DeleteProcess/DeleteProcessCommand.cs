using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;

namespace Wbc.Application.MasterItems.Command.DeleteProcess
{
    public class DeleteProcessCommand : IRequest, IMapFrom<Domain.Entities.Process>
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string ProcessDescription { get; set; }
        public string ProcessCode { get; set; }

        public class DeleteProcessCommandHandler : IRequestHandler<DeleteProcessCommand>
        {

            private readonly IApplicationDbContext _context;
            private readonly ICurrentUserService _userService;
            private readonly IDateTime _dateTime;

            public DeleteProcessCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
            {
                _context = context;
                _userService = userService;
                _dateTime = dateTime;
            }

            public async Task<Unit> Handle(DeleteProcessCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Processes.Where(l => l.Id == request.Id)

                 .SingleOrDefaultAsync(cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Domain.Entities.Process), request.Id);
                }

                entity.IsActive = false;
                entity.DeletedBy = _userService.GetUserId();
                entity.DeletedOn = _dateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
