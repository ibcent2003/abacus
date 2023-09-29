using System;
using AutoMapper;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.Workflow.Query.GetPendingApproval
{
    public class InboxDto : IMapFrom<Document>
    {
        public Guid WorkflowProcessId { get; set; }
        public string StateName { get; set; }
        public string ProcessName { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmittedOn { get; set; }
        public string DocumentSource { get; set; }
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Document, InboxDto>()
                .ForMember(d => d.DocumentSource, opt => opt.MapFrom(s => $"{s.DocumentSource}{s.Id}"));

        }
    }
}
