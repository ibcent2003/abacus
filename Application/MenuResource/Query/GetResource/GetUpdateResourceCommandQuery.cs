using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MenuResource.Commands.UpdateResource;
using Wbc.Application.MenuResource.Query.GetResourceArea;
using Wbc.Application.Permission.Query;
using Wbc.Application.Permission.Query.GetPermission;

namespace Wbc.Application.MenuResource.Query.GetResource
{
    public class GetUpdateResourceCommandQuery : IRequest<ResourceVm>
    {
        public int Id { get; set; }
    }

    public class GetUpdateResourceCommandQueryHandler : IRequestHandler<GetUpdateResourceCommandQuery, ResourceVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUpdateResourceCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResourceVm> Handle(GetUpdateResourceCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Resources.FindAsync(request.Id);

            return new ResourceVm
            {
                UpdateCommand = _mapper.Map<UpdateResourceCommand>(entity),
                ResourceAreas = await _context.ResourceAreas.Where(x => x.IsActive).ProjectTo<ResourceAreaDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
                Permissions = await _context.Permissions.ProjectTo<PermissionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }

}
