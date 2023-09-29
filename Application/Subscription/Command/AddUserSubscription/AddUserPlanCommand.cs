using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Exceptions;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;
using Wbc.Domain.Entities;

namespace Wbc.Application.Subscription.Command.AddUserSubscription
{
    public class AddUserPlanCommand : IRequest<string>
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int NumberOfUse { get; set; }
    }

    public class AddUserPlanCommandHandler : IRequestHandler<AddUserPlanCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly PaymentServiceConfiguration _paymentConfig;
        private readonly IPaymentService _paymentService;

        public AddUserPlanCommandHandler(IApplicationDbContext context,
            ICurrentUserService currentUserService,
            PaymentServiceConfiguration paymentConfig,
            IPaymentService paymentService)
        {
            _context = context;
            _currentUserService = currentUserService;
            _paymentConfig = paymentConfig;
            _paymentService = paymentService;
        }
        public async Task<string> Handle(AddUserPlanCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.GetUserId();
            if(userId==null)
            {
                return null;
            }

            var ogId = _currentUserService.GetUserOrganisationId();
            var userEmail = _currentUserService.GetUserClaim(Common.Enums.ClaimTypes.Name);
            

            var selectedPlan = await _context.SubscriptionPlans.Include(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == request.PlanId, cancellationToken);

            if (selectedPlan == null)
                throw new NotFoundException(nameof(SubscriptionPlan), request.Id);

            var amount = int.Parse(selectedPlan.Amout);
            try
            {
                var paymentDetail = new PaymentInvoiceModel
                {
                    Email = userEmail,
                    Amount = amount,
                    PayerOrgId = (ogId == 0 ? -2 : ogId),
                    PayeeOrgId = null,
                    Currency = selectedPlan.Country.CurrencyName,
                    ApplicationId = "Switch",
                    CallbackUrl = _paymentConfig.PaymentCallBackUrl,
                    PaymentName = "User Subscription"
                };
                var response = await _paymentService.RegisterPaymentInvoice(paymentDetail, cancellationToken);

                var transactionId = response.TransactionId;

                var tempPayment = new UserTemporaryPlan { TransactionId = transactionId, CreatedBy = userId, Created = DateTime.UtcNow, PlanId = selectedPlan.Id };
                
                _context.UserTemporaryPlans.Add(tempPayment);

                await _context.SaveChangesAsync(cancellationToken);

                return $"{_paymentConfig.PaymentUiBaseUrl}{_paymentConfig.PayStackUiUrl}{transactionId}";
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
