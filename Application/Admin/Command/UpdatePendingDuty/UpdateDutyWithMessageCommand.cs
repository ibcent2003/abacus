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

namespace Wbc.Application.Admin.Command.UpdatePendingDuty
{
    public class UpdateDutyWithMessageCommand : IRequest, IMapFrom<VehicleSearchPool>
    {
        public Guid TransactionId { get; set; }
        public string  DutyResult { get; set; }
    }
    public class UpdateDutyWithMessageCommandHandler : IRequestHandler<UpdateDutyWithMessageCommand>
    {

        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public UpdateDutyWithMessageCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;

        }

        public async Task<Unit> Handle(UpdateDutyWithMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.VehicleSearchPools.Where(x => x.TransactionId == request.TransactionId).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleSearchPool), request.TransactionId);
            }
            entity.CalculatedBy = _currentUserService.GetUserId();
            entity.DutyResult =request.DutyResult ;          
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
 }
