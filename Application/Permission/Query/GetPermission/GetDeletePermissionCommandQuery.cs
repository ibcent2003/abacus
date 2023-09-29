using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Permission.Commands.DeletePermission;

namespace Wbc.Application.Permission.Query.GetPermission
{
    public class GetDeletePermissionCommandQuery : IRequest<DeletePermissionCommand>
    {
        public int Id { get; set; }
    }

    public class GetDeletePermissionCommandQueryHandler : IRequestHandler<GetDeletePermissionCommandQuery, DeletePermissionCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDeletePermissionCommandQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeletePermissionCommand> Handle(GetDeletePermissionCommandQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Permissions.FindAsync(request.Id);

            return _mapper.Map<DeletePermissionCommand>(entity);
        }
    }
}
