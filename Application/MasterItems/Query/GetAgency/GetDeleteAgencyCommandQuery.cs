using Application.MasterItems.Command.DeleteAgency;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Application.MasterItems.Query.GetAgency
{
    public class GetDeleteAgencyCommandQuery : IRequest<DeleteAgencyCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeleteAgencyCommandQueryHandler : IRequestHandler<GetDeleteAgencyCommandQuery, DeleteAgencyCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeleteAgencyCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteAgencyCommand> Handle(GetDeleteAgencyCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Agencies.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            var AgencyDto = _mapper.Map<AgencyDto>(entity);

            return _mapper.Map<DeleteAgencyCommand>(AgencyDto);
        }
    }
}
