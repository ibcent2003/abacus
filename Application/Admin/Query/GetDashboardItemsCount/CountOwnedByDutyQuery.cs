using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Query.GetDashboardItemsCount
{
   public class CountOwnedByDutyQuery : IRequest<List<VehicleSearchPool>>
    {
    }

    public class CountOwnedByDutyQueryHandle : IRequestHandler<CountOwnedByDutyQuery, List<VehicleSearchPool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public CountOwnedByDutyQueryHandle(IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<List<VehicleSearchPool>> Handle(CountOwnedByDutyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _currentUserService.GetUserId();

                var result = await _context.VehicleSearchPools.Where(x => x.OwnedBy == userId && x.Status=="Processing").ToListAsync();
                return result;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
    }
