using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;

namespace Application.Subscription.Command.AddUserSubscription
{
    public class SendPaymentInfoCommand: IRequest<string>
    {
        public PaymentInvoiceModel PaymentInvoice { get; set; }
        public int PlanId { get; set; }
    }

    public class SendPaymentInfoCommandHandler : IRequestHandler<SendPaymentInfoCommand, string>
    {
        private readonly IPaymentService _paymentService;

        public SendPaymentInfoCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<string> Handle(SendPaymentInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _paymentService.RegisterPaymentInvoice(request.PaymentInvoice, cancellationToken);

                return response.TransactionId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
