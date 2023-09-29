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
using Wbc.Application.Common.Models;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Query.GetDocumentCategory
{
   public class GetDocumentCategoryListQuery : DataTableListRequestModel, IRequest<DataTableVm<DocumentCategoryDto>>
    {
    }

    public class GetDocumentCategoryListQueryHandler : IRequestHandler<GetDocumentCategoryListQuery, DataTableVm<DocumentCategoryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetDocumentCategoryListQueryHandler(IMapper mapper, IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<DataTableVm<DocumentCategoryDto>> Handle(GetDocumentCategoryListQuery request, CancellationToken cancellationToken)
        {

            var data = _context.DocumentCategories.Where(x => x.IsActive).AsQueryable();

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.CategoryName.Contains(request.search) || x.CategoryName.Contains(request.search));

            IQueryable<DocumentCategory> OrderingFunction(IQueryable<DocumentCategory> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.CategoryName) : m.OrderBy(x => x.CategoryName) : request.sortColumn == 1 ? m.OrderByDescending(x => x.CategoryName) : m.OrderByDescending(x => x.CategoryName);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<DocumentCategoryDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<DocumentCategoryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
