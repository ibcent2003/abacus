using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MasterItems.Query.GetCountry;

namespace Application.MasterItems.Query.GetHSCodePool
{
   public class GetAddHSCodePoolCommandQuery : IRequest<HSCodePoolVm>
    {
    }

    public class GetAddHSCodePoolCommandQueryHandler : IRequestHandler<GetAddHSCodePoolCommandQuery, HSCodePoolVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAddHSCodePoolCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HSCodePoolVm> Handle(GetAddHSCodePoolCommandQuery request, CancellationToken cancellationToken)
        {

            return new HSCodePoolVm
            {
               
                Countries = await _context.Countries.ProjectTo<CountryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
