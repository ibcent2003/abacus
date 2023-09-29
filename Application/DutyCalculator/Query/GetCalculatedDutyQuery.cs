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

namespace Wbc.Application.DutyCalculator.Query
{
    public class GetCalculatedDutyQuery : IRequest<CalculatedDuty>, IMapFrom<VehicleFactory>
    {
        public Guid TransactionId { get; set; }
    }
    public class GetCalculatedDutyQueryHandler : IRequestHandler<GetCalculatedDutyQuery, CalculatedDuty>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public GetCalculatedDutyQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<CalculatedDuty> Handle(GetCalculatedDutyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userId =  _currentUserService.GetUserId();
                var result = await _context.CalculatedDuties.Where(x => x.TransactionId == request.TransactionId && x.UserId == userId).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
 }
