using OptimaJet.Workflow.Core.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Wbc.Domain.Entities;

namespace Wbc.Application.Common.Interfaces
{
   public interface IVehicleService
    {
        IEnumerable<VehicleMake> GetMakes();
        IEnumerable<VehicleModel> GetModels(int makeId);
        IEnumerable<VehicleType> GetVehicleTypes(string makeName);
        IEnumerable<VehicleSpecialFeature> Getfeatures(int makeId);
        VehicleMake GetMakeName(int makeId);

        IEnumerable<Country> GetCountries();
        IEnumerable<Country> GetExportingCountries();
        Country GetCountryName(int countryId);
        Currency GetCurrency(int currencyId);
        Country GetCountry(string countryName);
        GuestUser GetGuestUser(string IP);
        UserTariffExtraTax GetUserTariffExtraTax(Guid transId);

      





    }
}
