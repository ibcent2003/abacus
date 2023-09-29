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
   public class GetUserTariffListQuery : IRequest<List<UserTariffExtraTax>>
    {
        public Guid TransactionId { get; set; }
    }

    public class GetUserTariffListQueryHandler : IRequestHandler<GetUserTariffListQuery, List<UserTariffExtraTax>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public GetUserTariffListQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<List<UserTariffExtraTax>> Handle(GetUserTariffListQuery request, CancellationToken cancellationToken)
        {
            try
            {
              //  var userId = _currentUserService.GetUserId();
                var result = await _context.UserTariffExtraTaxes.Where(x => x.TransactionId == request.TransactionId && x.TaxName != "Exchange Rate").ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
 }
