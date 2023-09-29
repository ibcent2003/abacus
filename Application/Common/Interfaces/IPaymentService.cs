using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Models;

namespace Wbc.Application.Common.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentInvoiceResponseModel> RegisterPaymentInvoice(PaymentInvoiceModel model, CancellationToken cancellationToken);
        Task<PaymentInvoiceResponseModel> VerifyPaymentInvoice(PaymentInvoiceResponseModel model, CancellationToken cancellationToken);
    }
}
