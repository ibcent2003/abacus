using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Permission.Commands.UpdatePermission;

namespace Wbc.Application.Permission.Query.GetPermission
{
    public class GetUpdatePermissionCommandQuery : IRequest<PermissionVm>
    {
        public int Id { get; set; }

    }


    public class GetUpdatePermissionCommandQueryHandler : IRequestHandler<GetUpdatePermissionCommandQuery, PermissionVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetUpdatePermissionCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PermissionVm> Handle(GetUpdatePermissionCommandQuery request, CancellationToken cancellationToken)
        {

            var entity = await _context.Permissions.FindAsync(request.Id);
            var updateCommand = _mapper.Map<UpdatePermissionCommand>(entity);
            var permissions = await _context.Resources.Where(x => x.IsActive).Select(x => x.Permission).ProjectTo<PermissionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new PermissionVm
            {
                UpdatePermissionCommand = updateCommand,
                PermissionDtos = permissions
            };

        }
    }
}
