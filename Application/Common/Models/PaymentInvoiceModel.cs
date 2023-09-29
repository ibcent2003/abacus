using System;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class PaymentInvoiceModel : IPayLoadObject
    {
        public string Email { get; set; }
        public int Amount { get; set; }
        public int PayerOrgId { get; set; }
        public int? PayeeOrgId { get; set; }
        public string Currency { get; set; }
        public string ApplicationId { get; set; }
        public string CallbackUrl { get; set; }
        public string PaymentName { get; set; }

        //public static implicit operator PaymentInvoiceModel(PaymentInvoiceModel v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
