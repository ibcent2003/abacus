using Application.MasterItems.Query.GetAgency;
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
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.DeleteAgency
{
   public class DeleteAgencyCommand : IRequest, IMapFrom<Agency>
    {
        public AgencyVm AgencyVm { get; set; }
    }

    public class DeleteAgencyCommandHandler : IRequestHandler<DeleteAgencyCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;
        private readonly IDateTime _dateTime;

        public DeleteAgencyCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
        {
            _context = context;
            _userService = userService;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Agencies.Where(l => l.Id == request.AgencyVm.AgencyDto.Id)

                 .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Agency), request.AgencyVm.AgencyDto.Id);
            }

            entity.IsActive = false;
            entity.DeletedBy = _userService.GetUserId();
            entity.DeletedOn = _dateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
