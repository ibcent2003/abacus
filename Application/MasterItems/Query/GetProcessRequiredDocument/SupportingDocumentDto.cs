using AutoMapper;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Query.GetProcessRequiredDocument
{
    public class SupportingDocumentDto : IMapFrom<ProcessRequiredDocument>
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string AllowedFormats { get; set; }
        public string ProcessName { get; set; }
        public int ProcessId { get; set; }
        public string ProcessCode { get; set; }
        public bool Mandatory { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProcessRequiredDocument, SupportingDocumentDto>()
                .ForMember(d => d.DocumentName, opt => opt.MapFrom(s => s.RequiredDocument.DocumentName))
                .ForMember(x => x.DocumentDescription, opt => opt.MapFrom(s => s.RequiredDocument.DocumentDescription))
                .ForMember(x => x.AllowedFormats, opt => opt.MapFrom(s => s.RequiredDocument.DocumentFormatString))
                .ForMember(x => x.ProcessId, opt => opt.MapFrom(s => s.Process.Id))
                .ForMember(x => x.ProcessName, opt => opt.MapFrom(s => s.Process.ProcessName));
        }
    }
}
