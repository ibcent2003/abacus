using System.Collections.Generic;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Query.GetProcessSubmittedDocument;

namespace Wbc.Application.Common.Models
{
    public class Subscriber : IPayLoadObject
    {
        public int Id { get; set; }
        public string Tin { get; set; }
        public string EntityName { get; set; }
        public string StreetNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string EmailAddress { get; set; }
        public string FaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public IList<ProcessSubmittedDocumentDto> SubmittedDocuments { get; set; }

    }
}
