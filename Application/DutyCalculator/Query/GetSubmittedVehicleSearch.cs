using AutoMapper;
using AutoMapper.QueryableExtensions;
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
using Wbc.Application.DutyCalculator.Command;
using Wbc.Application.MasterItems.Query.GetCountry;
using Wbc.Domain.Entities;

namespace Wbc.Application.DutyCalculator.Query
{
   public class GetSubmittedVehicleSearch :  IRequest<VehicleSearchPool>
    {
       
         public Guid TransactionId { get; set; }

        //public IEnumerable<Currency> currencies { get; set; }
    }
    public class GetSubmittedVehicleSearchHandler : IRequestHandler<GetSubmittedVehicleSearch, VehicleSearchPool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetSubmittedVehicleSearchHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<VehicleSearchPool> Handle(GetSubmittedVehicleSearch request, CancellationToken cancellationToken)
        {
            try
            {                
                var userId = _currentUserService.GetUserId();

                var result = await _context.VehicleSearchPools.Where(x => x.TransactionId == request.TransactionId && x.UserId == userId).FirstOrDefaultAsync();
                return result;
                
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
