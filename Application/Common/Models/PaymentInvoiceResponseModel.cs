using Wbc.Application.Common.Interfaces;

namespace Wbc.Application.Common.Models
{
    public class PaymentInvoiceResponseModel : IPayLoadObject
    {
        public string TransactionId { get; set; }
        public bool Status { get; set; }
    }
}
