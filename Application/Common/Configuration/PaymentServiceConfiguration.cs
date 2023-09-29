using System;
using System.Collections.Generic;
using System.Text;

namespace Wbc.Application.Common.Configuration
{
    public class PaymentServiceConfiguration
    {
        public string PaymentServiceBaseUrl { get; set; }
        public string RegisterPaymentInvoicePostUrl { get; set; }
        public string PaymentCallBackUrl { get; set; }
        public string PayStackUiUrl { get; set; }
        public string PaymentUiBaseUrl { get; set; }
        public string PaymentVerificationUrl { get; set; }
        public string PaymentSuccessUrl { get; set; }

    }
}
