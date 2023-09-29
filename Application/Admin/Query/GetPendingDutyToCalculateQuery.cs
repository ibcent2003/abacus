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
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Query
{
   public class GetPendingDutyToCalculateQuery : IRequest<UpdatePendingDutyToCalculatedCommand>
    {
        public Guid TransactionId { get; set; }
    }
    public class GetPendingDutyToCalculateQueryHandler : IRequestHandler<GetPendingDutyToCalculateQuery, UpdatePendingDutyToCalculatedCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPendingDutyToCalculateQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdatePendingDutyToCalculatedCommand> Handle(GetPendingDutyToCalculateQuery request, CancellationToken cancellationToken)
        {
           var entity = await _context.VehicleSearchPools.Where(x => x.TransactionId == request.TransactionId).FirstOrDefaultAsync();           
           return _mapper.Map<UpdatePendingDutyToCalculatedCommand>(entity);

           
        }
    }
 }
