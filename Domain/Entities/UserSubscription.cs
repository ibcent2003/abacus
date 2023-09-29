namespace Wbc.Domain.Entities
{
    public class UserSubscription
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public int SubscriberId { get; set; }
        private Subscriber Subscriber { get; set; }
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
    }
}
