using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Services
{
    public class TariffManagerService : ITariffManagerService
    {

        private readonly IApplicationDbContext _context;

        public TariffManagerService(IApplicationDbContext context)
        {
            _context = context;


        }
        public async Task<HSCodePool> GetHSCodeByCountry(HSCodePool hSCodePool, CancellationToken cancellationToken)
        {
            var GetHscode = await _context.HSCodePools.FirstOrDefaultAsync(x => x.CountryId == hSCodePool.CountryId);
            return GetHscode;
        }
    }
}
