using Automat.Application.Abstraction;

namespace Automat.Application
{
    public class PaymentOperationStrategy
    {
        private readonly IPaymentService _paymentService;

        public PaymentOperationStrategy(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public (string message, bool result) MakePayment(decimal money, decimal totalPrice)
        {
            return this._paymentService.MakePayment(money, totalPrice);
        }
    }
}
