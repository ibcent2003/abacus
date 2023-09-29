using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.Subscription.Query.GetSubscriber
{
    public class SubscriptionDto : IMapFrom<Subscriber>
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string AdminEmailAddress { get; set; }
        public string AdminPhoneNumber { get; set; }
        public int DocumentId { get; set; }

    }
}
