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

namespace Wbc.Application.Admin.Query
{
   public class GetSubmittedDutyCountQuery : IRequest<List<VehicleSearchPool>>
    {
    }
    public class GetSubmittedDutyCountQueryHandler : IRequestHandler<GetSubmittedDutyCountQuery, List<VehicleSearchPool>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetSubmittedDutyCountQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<List<VehicleSearchPool>> Handle(GetSubmittedDutyCountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _currentUserService.GetUserId();

                var result = await _context.VehicleSearchPools.Where(x => x.Status =="Pending").ToListAsync();
                return result;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
    }
