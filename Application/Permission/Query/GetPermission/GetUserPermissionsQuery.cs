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
    public class GetUserPermissionsQuery : IRequest<string>
    {
        public string UserId { get; set; }
    }

    public class GetUserPermissionQueryHandler : IRequestHandler<GetUserPermissionsQuery, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserPermissionQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<string> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
        {

            var vm = new PermissionVm
            {
                PermissionDtos = await _context.UserPermissions.Where(x => x.UserId.Equals(request.UserId)).Select(x => x.Permission).ProjectTo<PermissionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)

            };

            return vm.ToString();
        }
    }
}
