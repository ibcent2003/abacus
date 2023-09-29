using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IApplicationDbContext _dbContext;

        public CurrencyService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Currency> GetCurrncy()
        {
            IEnumerable<Currency> currencies = (from c in _dbContext.Currencies
                                                join e in _dbContext.ExchangeRates on c.Id equals e.CurrencyId
                                                where e.CountryId==1 && e.IsActive==true
                                                select c).ToList();
            return currencies;
        }

       
    }
}
