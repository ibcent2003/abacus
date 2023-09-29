using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Domain.Entities;

namespace Wbc.Application.Common.Interfaces
{
   public interface IDutyCalculatorService
    {
        Task<CalculatedDuty> GhanaCalculation(VehicleFactory vehicleFactory, CancellationToken cancellationToken);

        Task<CalculatedDuty> GhanaCalculateFromPool(VehicleSearchPool vehicleSearchPool, CancellationToken cancellationToken);

        


    }
}
