using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Permission.Query.GetOrganisationApprovalRole
{
    public class GetOrgaisationApprovalRoleListQuery : DataTableListRequestModel, IRequest<DataTableVm<OrganisationApprovalRoleDto>>
    {
    }

    public class GetOrgaisationApprovalRoleListQueryHandler : IRequestHandler<GetOrgaisationApprovalRoleListQuery, DataTableVm<OrganisationApprovalRoleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetOrgaisationApprovalRoleListQueryHandler(IMapper mapper, IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<DataTableVm<OrganisationApprovalRoleDto>> Handle(GetOrgaisationApprovalRoleListQuery request, CancellationToken cancellationToken)
        {
            var data = _context.OrganisationApprovalRoles.Where(x => x.IsActive).AsQueryable();

            if (_currentUserService.UserHasRole(Roles.TradeHubAdmin))
            {
                data = data.Where(x => x.SubscriberId == null);
            }
            else
            {
                var orgId = _currentUserService.GetUserOrganisationId();

                var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.ParentId == orgId, cancellationToken);

                data = data.Where(x => x.SubscriberId == subscriber.Id && !x.IsInternalUse);
            }

            var totalRecords = data.Count();

            if (request.length == -1) request.length = totalRecords;

            data = string.IsNullOrEmpty(request.search) ? data : data.Where(x => x.RoleName.Contains(request.search));

            IQueryable<Domain.Entities.OrganisationApprovalRole> OrderingFunction(IQueryable<Domain.Entities.OrganisationApprovalRole> m)
            {
                return request.sortDirection == "asc" ? request.sortColumn == 1 ? m.OrderBy(x => x.RoleName) : m.OrderBy(x => x.Id) : request.sortColumn == 1 ? m.OrderByDescending(x => x.RoleName) : m.OrderByDescending(x => x.Id);
            }

            var filteredData = OrderingFunction(data).Skip(request.start).Take(request.length);

            var dataTableData = new DataTableVm<OrganisationApprovalRoleDto>
            {
                draw = request.draw,
                recordsTotal = totalRecords,
                recordsFiltered = data.Count(),
                data = await filteredData.ProjectTo<OrganisationApprovalRoleDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };

            return dataTableData;

        }
    }
}
