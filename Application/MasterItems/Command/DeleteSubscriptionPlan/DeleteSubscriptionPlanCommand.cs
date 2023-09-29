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
using Wbc.Application.MasterItems.Query.GetSubscriptionPlan;


namespace Wbc.Application.MasterItems.Command.DeleteSubscriptionPlan
{
    public class DeleteSubscriptionPlanCommand : IRequest, IMapFrom<SubscriptionPlanDto>
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public string SubscriptionTypeName { get; set; }
        public int ValidityPeriod { get; set; }
        public string Description { get; set; }
        public string CountryName { get; set; }
        public string Amout { get; set; }
        public int NoOfUse { get; set; }
        public bool IsActive { get; set; }
    }
    public class DeleteSubscriptionPlanCommandHandler : IRequestHandler<DeleteSubscriptionPlanCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _userService;
        private readonly IDateTime _dateTime;

        public DeleteSubscriptionPlanCommandHandler(IApplicationDbContext context, ICurrentUserService userService, IDateTime dateTime)
        {
            _context = context;
            _userService = userService;
            _dateTime = dateTime;
        }

        public async Task<Unit> Handle(DeleteSubscriptionPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SubscriptionPlans.Where(l => l.Id == request.Id)

                 .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Wbc.Domain.Entities.SubscriptionPlan), request.Id);
            }
            entity.IsActive = false;
            entity.DeletedBy =  _userService.GetUserId();
            entity.DeletedOn = _dateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
