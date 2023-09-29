using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Infrastructure.Services 
{
    public class VehicleService : IVehicleService
    {
        private readonly IApplicationDbContext _dbContext;

        public VehicleService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<VehicleMake> GetMakes()
        {
            IEnumerable<VehicleMake> makes = _dbContext.VehicleMakes.Where(x=>x.IsActive==true).OrderBy(x=>x.MakeName).ToList();
            return makes;
        }
        public IEnumerable<VehicleModel> GetModels(int makeId)
        {
            IEnumerable<VehicleModel> model = _dbContext.VehicleModels.Where(x => x.VehicleMakeId == makeId && x.IsActive == true).OrderBy(x=>x.ModelName).ToList();
            return model;
        }
        public IEnumerable<VehicleType> GetVehicleTypes(string makeName)
        {
            IEnumerable<VehicleType> Vehicletypes = (from v in _dbContext.VehicleFactories
                                                     join t in _dbContext.VehicleTypes on v.VehicleType equals t.Name
                                                     where v.MakeName == makeName && t.IsActive == true orderby(t.Name)
                                                     select t).Distinct().ToList(); 
            return Vehicletypes;
        }
        public IEnumerable<VehicleSpecialFeature> Getfeatures(int makeId)
        {
            IEnumerable<VehicleSpecialFeature> features = _dbContext.VehicleSpecialFeatures.Where(x => x.VehicleMakeId == makeId && x.IsActive==true).ToList();
           
            return features;
        }
        public VehicleMake GetMakeName(int makeId)
        {
            VehicleMake makeName = _dbContext.VehicleMakes.Where(x => x.Id == makeId).FirstOrDefault();
            return makeName;
        }

        //Countries 
        public IEnumerable<Country> GetCountries()
        {

            IEnumerable<Country> countries = (from c in _dbContext.Countries
                                              join h in _dbContext.HSCodePools
                                              on c.Id equals h.CountryId
                                              where c.IsActive == true
                                              select c).OrderBy(x => x.CountryName).Distinct().ToList();
            return countries;

            //if(countryname==null)
            //{

            //}
            //else
            //{
            //    IEnumerable<Country> countries = (from c in _dbContext.Countries
            //                                      join h in _dbContext.HSCodePools
            //                                      on c.Id equals h.CountryId
            //                                      where c.IsActive == true && c.CountryName==countryname
            //                                      select c).OrderBy(x => x.CountryName).Distinct().ToList();
            //    return countries;
            //}


        }
        public IEnumerable<Country> GetExportingCountries()
        {
            IEnumerable<Country> countries = _dbContext.Countries.Where(x => x.IsActive == true).OrderBy(x => x.CountryName).ToList();
            return countries;
        }


        public Country GetCountryName(int countryId)
        {
            Country country = _dbContext.Countries.Where(x => x.Id == countryId).FirstOrDefault();
            return country;
        }

        public Currency GetCurrency(int currencyId)
        {
            Currency currency = _dbContext.Currencies.Where(x => x.Id == currencyId).FirstOrDefault();
            return currency;
        }

        public Country GetCountry(string countryName)
        {
            Country country = _dbContext.Countries.Where(x => x.CountryName == countryName).FirstOrDefault();
            return country;
        }
        public GuestUser GetGuestUser(string guestCookie)
        {
            GuestUser guest = _dbContext.GuestUsers.Where(x => x.Ip == guestCookie).FirstOrDefault();
            return guest;
        }

        public UserTariffExtraTax GetUserTariffExtraTax(Guid transId)
        {
            var getExtra = _dbContext.UserTariffExtraTaxes.Where(x => x.TransactionId == transId && x.TaxName == "Exchange Rate").FirstOrDefault();
            return getExtra;
        }

        //public static string GetCompCode() 
        //{
        //    string strHostName = "";
        //    strHostName = Dns.GetHostName();
        //    return strHostName;
        //}

    }
}










