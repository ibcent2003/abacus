using Application.MasterItems.Command.UpdateDocumentCategory;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Application.MasterItems.Query.GetDocumentCategory
{
   public class GetUpdateDocumentCategoryCommandQuery : IRequest<UpdateDocumentCategoryCommand>
    {
        public int Id { get; set; }
    }

    public class GetUpdateDocumentCategoryCommandQueryHandler : IRequestHandler<GetUpdateDocumentCategoryCommandQuery, UpdateDocumentCategoryCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetUpdateDocumentCategoryCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UpdateDocumentCategoryCommand> Handle(GetUpdateDocumentCategoryCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.DocumentCategories.FindAsync(request.Id);

            return _mapper.Map<UpdateDocumentCategoryCommand>(entity);
        }
    }
}
