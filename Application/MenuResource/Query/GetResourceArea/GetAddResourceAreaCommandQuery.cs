using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MenuResource.Query.GetTopResource;

namespace Wbc.Application.MenuResource.Query.GetResourceArea
{
    public class GetAddResourceAreaCommandQuery : IRequest<ResourceAreaVm>
    {

    }

    public class GetAddResourceAreaCommandQueryHandler : IRequestHandler<GetAddResourceAreaCommandQuery, ResourceAreaVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAddResourceAreaCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResourceAreaVm> Handle(GetAddResourceAreaCommandQuery request, CancellationToken cancellationToken)
        {
            return new ResourceAreaVm
            {
                ResourceHeaders = await _context.TopResources.Where(x => x.IsActive).ProjectTo<TopResourceDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
            };
        }
    }
}
