namespace Wbc.Domain.Entities
{
    public class SubscriberProcessWorkflow
    {
        public int Id { get; set; }
        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }
        public int ProcessId { get; set; }
        public Process Process { get; set; }
        public string WorkflowSchemeCode { get; set; }

    }
}
