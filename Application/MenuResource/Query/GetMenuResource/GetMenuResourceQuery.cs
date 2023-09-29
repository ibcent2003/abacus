using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MenuResource.Query.GetResource;

namespace Wbc.Application.MenuResource.Query.GetMenuResource
{
    public class GetMenuResourceQuery : IRequest<ResourceMenuVm>
    {
        public string UserId { get; set; }
    }

    public class GetMenuResourceQueryHandler : IRequestHandler<GetMenuResourceQuery, ResourceMenuVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMenuResourceQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResourceMenuVm> Handle(GetMenuResourceQuery request, CancellationToken cancellationToken)
        {
            var userpermissions = await _context.UserPermissions.Where(x => x.UserId.Equals(request.UserId)).Select(x => x.PermissionId).ToListAsync(cancellationToken);

            return new ResourceMenuVm { Resource = await _context.Resources.Where(x => userpermissions.Contains(x.PermissionId)).ProjectTo<ResourceDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken) };
        }
    }
}