using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.Admin.Query.GetDashboardItemsCount
{
    public class CountAllCalculatedDutyQuery : IRequest<List<CalculatedDuty>>
    {
    }
    public class CountAllCalculatedDutyQueryHandler : IRequestHandler<CountAllCalculatedDutyQuery, List<CalculatedDuty>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public CountAllCalculatedDutyQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<List<CalculatedDuty>> Handle(CountAllCalculatedDutyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _currentUserService.GetUserId();
                var result = await _context.CalculatedDuties.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}