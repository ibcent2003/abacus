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
using Wbc.Application.MasterItems.Query.GetSubscriptionType;

namespace Application.MasterItems.Query.GetSubscriptionType
{
    public class GetSubscriptionType : IRequest<List<SubscriptionTypeDto>>
    {

    }

    public class GetSubscriptionTypeHandler : IRequestHandler<GetSubscriptionType, List<SubscriptionTypeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSubscriptionTypeHandler(IApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

   
  
        public async Task<List<SubscriptionTypeDto>> Handle(GetSubscriptionType request, CancellationToken cancellationToken)
        {
            return await _context.SubscriptionTypes.ProjectTo<SubscriptionTypeDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }
    }
}
