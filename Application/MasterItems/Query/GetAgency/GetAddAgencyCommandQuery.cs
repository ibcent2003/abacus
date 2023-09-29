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
   public class GetAddAgencyCommandQuery : IRequest<AgencyVm>
    {
    }

    public class GetAddAgencyCommandQueryHandler : IRequestHandler<GetAddAgencyCommandQuery, AgencyVm>
    {

        public GetAddAgencyCommandQueryHandler()
        {
        }

        public async Task<AgencyVm> Handle(GetAddAgencyCommandQuery request, CancellationToken cancellationToken)
        {

            return new AgencyVm
            {
                AgencyDto = new AgencyDto()
            };
        }
    }
}
