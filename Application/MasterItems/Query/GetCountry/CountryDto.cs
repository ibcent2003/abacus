using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Query.GetCountry
{
    public class CountryDto : IMapFrom<Country>
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsActive { get; set; }
    }
}
