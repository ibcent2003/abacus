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

namespace Wbc.Application.GeneralGoods.Query
{
   public class GetUserHScodePoolQuery : IRequest<UserHSCodePool>
    {
        public Guid TransactionId { get; set; }
    }
    public class GetGeneralGoodDutyQueryHandler : IRequestHandler<GetUserHScodePoolQuery, UserHSCodePool>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public GetGeneralGoodDutyQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<UserHSCodePool> Handle(GetUserHScodePoolQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _currentUserService.GetUserId();
                var result = await _context.UserHSCodePools.Where(x => x.TransactionId == request.TransactionId && x.UserId == userId).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
 }
