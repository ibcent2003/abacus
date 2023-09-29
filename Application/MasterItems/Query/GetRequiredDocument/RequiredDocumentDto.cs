using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Wbc.Application.MasterItems.Query.GetRequiredDocument
{
    public class RequiredDocumentDto : IMapFrom<RequiredDocument>
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentFormatString { get; set; }
        public string MaximumSize { get; set; }
        public DateTime ExpiryDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequiredDocument, RequiredDocumentDto>()
                .ForMember(d => d.DocumentName, opt => opt.MapFrom(s => s.DocumentName))
                .ForMember(x => x.DocumentDescription, opt => opt.MapFrom(s => s.DocumentDescription))
                .ForMember(x => x.DocumentFormatString, opt => opt.MapFrom(s => s.DocumentFormatString))
                .ForMember(x => x.MaximumSize, opt => opt.MapFrom(s => s.MaximumSize));

        }
    }
}
