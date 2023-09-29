using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Query
{
   public class GetManualCalculatedDutyQuery : IRequest<CalculatedDuty>, IMapFrom<VehicleFactory>
    {
        public Guid TransactionId { get; set; }
    }
    public class GetManualCalculatedDutyQueryHandler : IRequestHandler<GetManualCalculatedDutyQuery, CalculatedDuty>
    {
        private readonly IApplicationDbContext _context;
     
        public GetManualCalculatedDutyQueryHandler(IApplicationDbContext context)
        {
            _context = context;
          
        }

        public async Task<CalculatedDuty> Handle(GetManualCalculatedDutyQuery request, CancellationToken cancellationToken)
        {
            try
            {
               
                var result = await _context.CalculatedDuties.Where(x => x.TransactionId == request.TransactionId).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
  }
