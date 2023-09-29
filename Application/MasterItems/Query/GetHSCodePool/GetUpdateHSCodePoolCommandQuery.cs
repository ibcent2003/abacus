using Application.MasterItems.Command.UpdateHSCodePool;
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
    public class GetUpdateHSCodePoolCommandQuery : IRequest<HSCodePoolVm>
    {
        public int Id { get; set; }
    }


    public class GetUpdateHSCodePoolCommandQueryHandler : IRequestHandler<GetUpdateHSCodePoolCommandQuery, HSCodePoolVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateHSCodePoolCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HSCodePoolVm> Handle(GetUpdateHSCodePoolCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.HSCodePools.FindAsync(request.Id);

            return new HSCodePoolVm
            {
                UpdateHSCodePoolCommand = _mapper.Map<UpdateHSCodePoolCommand>(entity),
                Countries = await _context.Countries.ProjectTo<CountryDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
