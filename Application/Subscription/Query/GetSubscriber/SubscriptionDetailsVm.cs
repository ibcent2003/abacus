using System.Collections.Generic;
using Wbc.Application.MasterItems.Query.GetProcessSubmittedDocument;

namespace Wbc.Application.Subscription.Query.GetSubscriber
{
    public class SubscriptionDetailsVm
    {
        public SubscriptionDetailsVm()
        {
            SubmittedDocuments = new List<ProcessSubmittedDocumentDto>();
        }

        public SubscriptionDto SubscriptionDto { get; set; }
        public IList<ProcessSubmittedDocumentDto> SubmittedDocuments { get; set; }
    }
}
