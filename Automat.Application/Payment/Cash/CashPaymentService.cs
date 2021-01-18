using Automat.Application.Abstraction;

namespace Automat.Application
{
    public class CashPaymentService : IPaymentService
    {
        public (string message, bool result) MakePayment(decimal money, decimal totalPrice)
        {
            if (money < totalPrice)
            {
                return ("Yetersiz Bakiye", false);
            }
            else
            {
                return (string.Format("Nakit Ödeme ile {0} TL tutarında ödeme alınmıştır.{1} TL tutar para iade edilmiştir.", money, money - totalPrice), true);
            }
        }
    }
}
