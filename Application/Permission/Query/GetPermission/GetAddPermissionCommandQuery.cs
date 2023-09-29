using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Permission.Query.GetPermission
{
    public class GetAddPermissionCommandQuery : IRequest<PermissionVm>
    {
    }

    public class GetAddPermissionCommandQueryHandler : IRequestHandler<GetAddPermissionCommandQuery, PermissionVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAddPermissionCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PermissionVm> Handle(GetAddPermissionCommandQuery request, CancellationToken cancellationToken)
        {
            var permissions = await _context.Resources.Where(x => x.IsActive).Select(x => x.Permission).ProjectTo<PermissionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new PermissionVm { PermissionDtos = permissions };
        }
    }
}
