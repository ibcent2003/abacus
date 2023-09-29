using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Command.UpdatePendingDuty
{
    public class UpdatePendingDutyOwnedByCommand : IRequest, IMapFrom<VehicleSearchPool>
    {
        public Guid TransactionId { get; set; }       
    }

    public class UpdatePendingDutyOwnedByCommandHanlder : IRequestHandler<UpdatePendingDutyOwnedByCommand>
    {

        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public UpdatePendingDutyOwnedByCommandHanlder(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

        }

        public async Task<Unit> Handle(UpdatePendingDutyOwnedByCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VehicleSearchPools.FindAsync(request.TransactionId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleSearchPool), request.TransactionId);
            }
            entity.Status = "Processing";
            entity.OwnedBy = _currentUserService.GetUserId(); 
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
 }
