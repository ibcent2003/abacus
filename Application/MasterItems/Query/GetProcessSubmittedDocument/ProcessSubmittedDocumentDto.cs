using AutoMapper;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Query.GetProcessSubmittedDocument
{
    public class ProcessSubmittedDocumentDto : IMapFrom<ProcessSubmittedDocument>
    {
        public int DocumentOwnerId { get; set; }
        public string DocumentUrl { get; set; }
        public string DocumentExtension { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProcessSubmittedDocument, ProcessSubmittedDocumentDto>()
                .ForMember(d => d.DocumentDescription, opt => opt.MapFrom(s => s.ProcessRequiredDocument.RequiredDocument.DocumentDescription));

        }
    }
}
