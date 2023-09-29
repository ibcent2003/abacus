using System.Collections.Generic;
using Wbc.Domain.Common;

namespace Wbc.Domain.Entities
{
    public class Subscriber : HasWorkflowApprovalProcess
    {
        public Subscriber()
        {
            UserSubscriptions = new List<UserSubscription>();
            OrganisationApprovalRoles = new List<OrganisationApprovalRole>();
        }

        public int Id { get; set; }
        public string Tin { get; set; }
        public string EntityName { get; set; }
        public string StreetNumber { get; set; }
        public string PostCode { get; set; }
        public string EntityTypeCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string EmailAddress { get; set; }
        public string FaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int ParentId { get; set; }
        public ICollection<UserSubscription> UserSubscriptions { get; set; }
        public ICollection<OrganisationApprovalRole> OrganisationApprovalRoles { get; set; }

    }
}
