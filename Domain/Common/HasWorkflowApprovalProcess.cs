using System;
using System.ComponentModel.DataAnnotations;
using Wbc.Domain.Entities;

namespace Wbc.Domain.Common
{
    public abstract class HasWorkflowApprovalProcess
    {
        [Required]
        [MaxLength(100)]
        public string WorkflowSchemeCode { get; set; }
        [Required]
        public int DocumentId { get; set; }
        public Document Document { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProcessName { get; set; }
        [Required]
        [MaxLength(100)]
        public string DocumentSource { get; set; }
    }
}
