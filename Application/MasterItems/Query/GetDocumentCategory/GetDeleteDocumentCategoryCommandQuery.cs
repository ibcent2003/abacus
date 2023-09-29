using Application.MasterItems.Command.DeleteDocumentCategory;
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
   public class GetDeleteDocumentCategoryCommandQuery : IRequest<DeleteDocumentCategoryCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteDocumentCategoryCommandQueryHandler : IRequestHandler<GetDeleteDocumentCategoryCommandQuery, DeleteDocumentCategoryCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeleteDocumentCategoryCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteDocumentCategoryCommand> Handle(GetDeleteDocumentCategoryCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.DocumentCategories.FindAsync(request.Id);

            return _mapper.Map<DeleteDocumentCategoryCommand>(entity);
        }
    }
}
