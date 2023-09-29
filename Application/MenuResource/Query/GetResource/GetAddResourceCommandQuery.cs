using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MenuResource.Query.GetResourceArea;
using Wbc.Application.Permission.Query;
using Wbc.Application.Permission.Query.GetPermission;

namespace Wbc.Application.MenuResource.Query.GetResource
{
    public class GetAddResourceCommandQuery : IRequest<ResourceVm>
    {
    }

    public class GetAddResourceCommandQueryHandler : IRequestHandler<GetAddResourceCommandQuery, ResourceVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAddResourceCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResourceVm> Handle(GetAddResourceCommandQuery request, CancellationToken cancellationToken)
        {

            return new ResourceVm
            {
                ResourceAreas = await _context.ResourceAreas.Where(x => x.IsActive).ProjectTo<ResourceAreaDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
                Permissions = await _context.Permissions.ProjectTo<PermissionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
