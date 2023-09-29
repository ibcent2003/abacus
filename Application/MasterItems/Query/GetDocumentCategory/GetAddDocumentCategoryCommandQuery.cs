using Application.MasterItems.Query.GetDocumentType;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Application.MasterItems.Query.GetDocumentCategory
{
    public class GetAddDocumentCategoryCommandQuery : IRequest<DocumentCategoryVm>
    {
    }

    public class GetAddDocumentCategoryCommandQueryHandler : IRequestHandler<GetAddDocumentCategoryCommandQuery, DocumentCategoryVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAddDocumentCategoryCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DocumentCategoryVm> Handle(GetAddDocumentCategoryCommandQuery request, CancellationToken cancellationToken)
        {

            return new DocumentCategoryVm
            {
                DocumentTypes = await _context.DocumentTypes.Where(x => x.IsActive).ProjectTo<DocumentTypeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
