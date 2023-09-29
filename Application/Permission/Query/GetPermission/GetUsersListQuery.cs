using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Permission.Query.GetPermission
{
    public class GetUsersListQuery : DataTableListRequestModel, IRequest<DataTableVm<User>>
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }

    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, DataTableVm<User>>
    {
        private readonly ISsoService _ssoService;
        public GetUsersListQueryHandler(ISsoService ssoService)
        {
            _ssoService = ssoService;
        }

        public async Task<DataTableVm<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {

            var filteredData = await _ssoService.GetUsersByClaimAsync(new ApiSearchModel
            {
                ClaimType = request.ClaimType,
                ClaimValue = request.ClaimValue,

                Page = request.start,
                PageSize = request.length
            },
                cancellationToken);

            var dataTableData = new DataTableVm<User>
            {
                draw = request.draw,
                recordsTotal = filteredData.TotalCount,
                recordsFiltered = filteredData.PageSize,
                data = filteredData.Users
            };

            return dataTableData;
        }
    }
}
