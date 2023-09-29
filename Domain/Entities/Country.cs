namespace Wbc.Domain.Entities
{
    public class Country
    {
        //public int Id { get; set; }
        //public string CountryName { get; set; }
        //public string OfficialStateName { get; set; }
        //public string CountryCode { get; set; }

        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsActive { get; set; }
    }
}
