using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Application.Common.Mappings;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Query.GetDocumentCategory
{
   public class DocumentCategoryDto : IMapFrom<DocumentCategory>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public bool IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DocumentCategory, DocumentCategoryDto>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.CategoryName));
              //  .ForMember(x => x.DocumentType, opt => opt.MapFrom(s => s.DocumentTypeId));

        }
    }
}
