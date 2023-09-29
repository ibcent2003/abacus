﻿using AutoMapper;
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

namespace Wbc.Application.MasterItems.Query.GetCountry
{
   public class GetCountryListQuery : DataTableListRequestModel, IRequest<DataTableVm<CountryDto>>
    {
    }

    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, DataTableVm<CountryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetCountryListQueryHandler(IMapper mapper, IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<DataTableVm<CountryDto>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {

            var data = _context.Countries.AsQueryable();
            var totalRecords = data.Count();
            if (request.length == -1) request.length = totalRecords;
            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.CountryName.Contains(request.search) || x.CountryName.Contains(request.search));
            IQueryable<Domain.Entities.Country> OrderingFunction(IQueryable<Domain.Entities.Country> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.CountryName) : m.OrderBy(x => x.CountryName) : request.sortColumn == 1 ? m.OrderByDescending(x => x.CountryName) : m.OrderByDescending(x => x.CountryName);
            }
            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<CountryDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<CountryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;
        }
    }
}
