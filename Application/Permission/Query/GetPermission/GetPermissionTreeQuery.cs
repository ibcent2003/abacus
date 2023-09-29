using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Permission.Query.GetPermission
{
    public class GetPermissionTreeQuery : IRequest<List<RootMenuModel>>
    {

        public string Id { get; set; }

    }

    public class GetPermissionTreeQueryHandler : IRequestHandler<GetPermissionTreeQuery, List<RootMenuModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        public GetPermissionTreeQueryHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<List<RootMenuModel>> Handle(GetPermissionTreeQuery request, CancellationToken cancellationToken)
        {
            var assignedPermissions = await _context.UserPermissions.Where(x => x.UserId.Equals(request.Id)).Select(x => x.PermissionId).ToListAsync(cancellationToken);

            var data = _context.Resources.Select(x => x.Permission);

            var parentList = await data.Where(x => x.IsActive).WhereIf(!_currentUserService.UserHasRole(Roles.TradeHubAdmin), x => !x.RequireAdminRole).ToListAsync(cancellationToken);

            return parentList.OrderBy(x => x.PermissionName).Select(x => new RootMenuModel
            {
                Text = x.PersmissionDescription,
                Id = x.Id.ToString(),
                State = new StateModel { Opened = true, Selected = assignedPermissions.Contains(x.Id) },
                Type = "root",
                Icon = "fas fa-fw fa-ellipsis-h",
                Children = _context.Permissions.Where(y => y.IsActive && y.DependentPermissionId == x.Id).OrderBy(y => y.PermissionName).WhereIf(!_currentUserService.UserHasRole(Roles.TradeHubAdmin), y => !y.RequireAdminRole).Select(y => new RootMenuModel
                {
                    Id = y.Id.ToString(),
                    Text = y.PersmissionDescription,
                    Icon = "fas fa-fw fa-ellipsis-v",
                    State = new StateModel
                    {
                        Opened = true,
                        Selected = assignedPermissions.Contains(y.Id)
                    }
                }).ToList()
            }).ToList();

        }
    }
}
