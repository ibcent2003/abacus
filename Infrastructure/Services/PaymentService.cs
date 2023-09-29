using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IWbcSsoHttpClientService _clientService;
        private readonly PaymentServiceConfiguration _paymentServiceConfiguration;
        private readonly AdminConfiguration _adminConfiguration;

        public PaymentService(PaymentServiceConfiguration paymentServiceConfiguration, IWbcSsoHttpClientService clientService, AdminConfiguration adminConfiguration)
        {
            _paymentServiceConfiguration = paymentServiceConfiguration;
            _clientService = clientService;
            _adminConfiguration = adminConfiguration;
        }

        public async Task<PaymentInvoiceResponseModel> RegisterPaymentInvoice(PaymentInvoiceModel model, CancellationToken cancellationToken)
        {
            var postUrl = $"{_paymentServiceConfiguration.PaymentServiceBaseUrl}{_paymentServiceConfiguration.RegisterPaymentInvoicePostUrl}";

            return await _clientService.PostWithTokenAsync<PaymentInvoiceResponseModel>(model, _adminConfiguration.PaymentApiScope, postUrl, cancellationToken);
        }

        public async Task<PaymentInvoiceResponseModel> VerifyPaymentInvoice(PaymentInvoiceResponseModel model, CancellationToken cancellationToken)
        {
            var postUrl = $"{_paymentServiceConfiguration.PaymentServiceBaseUrl}{_paymentServiceConfiguration.PaymentVerificationUrl}";

            return await _clientService.PostWithTokenAsync<PaymentInvoiceResponseModel>(model, _adminConfiguration.PaymentApiScope, postUrl, cancellationToken);

        }
    }
}
