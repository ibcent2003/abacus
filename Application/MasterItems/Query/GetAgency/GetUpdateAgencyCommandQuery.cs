using Application.MasterItems.Command.UpdateAgency;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;

namespace Application.MasterItems.Query.GetAgency
{
    public class GetUpdateAgencyCommandQuery : IRequest<AgencyVm>
    {
        public int Id { get; set; }
    }

    public class GetUpdateAgencyCommandQueryHandler : IRequestHandler<GetUpdateAgencyCommandQuery, AgencyVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateAgencyCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AgencyVm> Handle(GetUpdateAgencyCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Agencies.FindAsync(request.Id);

            return new AgencyVm
            {
                UpdateAgency = _mapper.Map<UpdateAgencyCommand>(entity),
            };

        }
    }
}
