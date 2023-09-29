using Application.MasterItems.Command.UpdateDocumentCategory;
using Application.MasterItems.Query.GetDocumentType;
using System;
using System.Collections.Generic;
using System.Text;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Query.GetDocumentCategory
{
    public class DocumentCategoryVm
    {
        public DocumentCategoryVm()
        {
            DocumentTypes = new List<DocumentTypeDto>();
        }

        public DocumentCategoryDto DocumentCategoryDto { get; set; }
        public IList<DocumentTypeDto> DocumentTypes { get; set; }
        public int DocumentTypeId { get; set; }

        public UpdateDocumentCategoryCommand UpdateDocumentCategoryCommand { get; set; }
    }
}
