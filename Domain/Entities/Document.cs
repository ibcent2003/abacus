using System;
using System.Collections.Generic;

namespace Wbc.Domain.Entities
{
    public class Document
    {
        public Document()
        {
            DocumentTransitionHistories = new List<DocumentTransitionHistory>();
        }
        public int Id { get; set; }
        public string State { get; set; }
        public string AuthorId { get; set; }
        public bool IsFinalised { get; set; }
        public string StateName { get; set; }
        public string ProcessName { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string DocumentSource { get; set; }
        public Guid WorkflowProcessId { get; set; }
        public ICollection<DocumentTransitionHistory> DocumentTransitionHistories { get; set; }

    }
}
