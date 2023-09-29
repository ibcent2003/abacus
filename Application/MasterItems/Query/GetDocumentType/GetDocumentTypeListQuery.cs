using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Query.GetDocumentType
{
    public class GetDocumentTypeListQuery : DataTableListRequestModel, IRequest<DataTableVm<DocumentTypeDto>>
    {
    }

    public class GetDocumentTypeListQueryHandler : IRequestHandler<GetDocumentTypeListQuery, DataTableVm<DocumentTypeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDocumentTypeListQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<DataTableVm<DocumentTypeDto>> Handle(GetDocumentTypeListQuery request, CancellationToken cancellationToken)
        {

            var data = _context.DocumentTypes.Where(x => x.IsActive).AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.DocumentTypeName.Contains(request.search) || x.DocumentTypeCode.Contains(request.search));

            IQueryable<DocumentType> OrderingFunction(IQueryable<DocumentType> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.DocumentTypeName) : m.OrderBy(x => x.DocumentTypeCode) : request.sortColumn == 1 ? m.OrderByDescending(x => x.DocumentTypeName) : m.OrderByDescending(x => x.DocumentTypeCode);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<DocumentTypeDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<DocumentTypeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
