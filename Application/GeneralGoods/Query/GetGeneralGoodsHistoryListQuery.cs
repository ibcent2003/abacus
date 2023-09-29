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

namespace Wbc.Application.GeneralGoods.Query
{
    public class GetGeneralGoodsHistoryListQuery : DataTableListRequestModel, IRequest<DataTableVm<UserHSCodePoolDto>>
    {
       
    }

    public class GetGeneralGoodsHistoryListQueryHandler : IRequestHandler<GetGeneralGoodsHistoryListQuery, DataTableVm<UserHSCodePoolDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetGeneralGoodsHistoryListQueryHandler(IMapper mapper, IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<DataTableVm<UserHSCodePoolDto>> Handle(GetGeneralGoodsHistoryListQuery request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            var data = _context.UserHSCodePools.Where(x=>x.UserId== userId).AsQueryable();
            var totalRecords = data.Count();
            if (request.length == -1) request.length = totalRecords;
            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.HsCode.Contains(request.search) || x.HsCode.Contains(request.search));
            IQueryable<Domain.Entities.UserHSCodePool> OrderingFunction(IQueryable<Domain.Entities.UserHSCodePool> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.Country.CountryName) : m.OrderBy(x => x.Country.CountryName) : request.sortColumn == 1 ? m.OrderByDescending(x => x.HsCode) : m.OrderByDescending(x => x.HsCode);
            }
            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<UserHSCodePoolDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<UserHSCodePoolDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }

}
