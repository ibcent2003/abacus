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
  public  class GetGuestHSCodePoolQuery : IRequest<UserHSCodePool>
    {
        public Guid TransactionId { get; set; }
        public string Ip { get; set; }
    }
    public class GetGuestHSCodePoolQueryHandler : IRequestHandler<GetGuestHSCodePoolQuery, UserHSCodePool>
    {
        private readonly IApplicationDbContext _context;
     
        public GetGuestHSCodePoolQueryHandler(IApplicationDbContext context)
        {
            _context = context;
          
        }

        public async Task<UserHSCodePool> Handle(GetGuestHSCodePoolQuery request, CancellationToken cancellationToken)
        {
            try
            {
               
                var result = await _context.UserHSCodePools.Where(x => x.TransactionId == request.TransactionId && x.UserId == request.Ip).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
