using AutoMapper;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Query.GetDocumentType
{
   public class DocumentTypeDto : IMapFrom<DocumentType>
    {
        public int Id { get; set; }
        public string DocumentTypeCode { get; set; }
        public string DocumentTypeName { get; set; }
        public bool IsActive { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DocumentType, DocumentTypeDto>()
                .ForMember(d => d.DocumentTypeName, opt => opt.MapFrom(s => s.DocumentTypeName))
                .ForMember(x => x.DocumentTypeCode, opt => opt.MapFrom(s => s.DocumentTypeCode));

        }
    }
}
