using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Domain.Entities;

namespace Wbc.Application.Common.Interfaces
{
   public interface ITariffManagerService
    {
        Task<HSCodePool> GetHSCodeByCountry(HSCodePool hSCodePool, CancellationToken cancellationToken);

       // Task<Tariff> GetTariffByHSCode(Tariff tariff, CancellationToken cancellationToken);

       // Task<HSCodeTariffTax> GetHSCodeTariffTax(HSCodeTariffTax hSCodeTariffTax, CancellationToken cancellationToken);
    }
}
