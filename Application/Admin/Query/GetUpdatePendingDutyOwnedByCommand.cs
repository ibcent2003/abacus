using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Admin.Command.UpdatePendingDuty;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Query
{
    public class GetUpdatePendingDutyOwnedByCommand:IRequest<UpdatePendingDutyOwnedByCommand>
    {
        public Guid TransactionId { get; set; }
    }
    public class GetUpdatePendingDutyOwnedByCommandHandler: IRequestHandler<GetUpdatePendingDutyOwnedByCommand, UpdatePendingDutyOwnedByCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public GetUpdatePendingDutyOwnedByCommandHandler(IApplicationDbContext context, IMapper mapper, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<UpdatePendingDutyOwnedByCommand> Handle(GetUpdatePendingDutyOwnedByCommand request, CancellationToken cancellationToken)
        {          
            var entity = await _context.VehicleSearchPools.Where(x => x.TransactionId == request.TransactionId).FirstOrDefaultAsync();// .FindAsync(request.TransactionId); //await _context.VehicleSearchPools.FindAsync(request.TransactionId);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(VehicleSearchPool), request.TransactionId);
            }

            entity.Status = "Processing";
            entity.OwnedBy = _currentUserService.GetUserId();
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UpdatePendingDutyOwnedByCommand>(entity);



        }
    }
 }
