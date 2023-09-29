using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Mappings;

namespace Wbc.Application.Permission.Commands.DeleteOrganisationApprovalRole
{
    public class DeleteOrganisationApprovalRoleCommand : IRequest, IMapFrom<Domain.Entities.OrganisationApprovalRole>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsInternalUse { get; set; }
        public int? SubscriberId { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteOrganisationApprovalRoleCommandHandler : IRequestHandler<DeleteOrganisationApprovalRoleCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;
        private readonly IDateTime _dateTime;

        public DeleteOrganisationApprovalRoleCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
        {
            _context = context;
            _userService = userService;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeleteOrganisationApprovalRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.OrganisationApprovalRoles.Where(l => l.Id == request.Id)

                 .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.OrganisationApprovalRole), request.Id);
            }

            entity.IsActive = false;
            entity.DeletedBy = _userService.GetUserId();
            entity.DeletedOn = _dateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
