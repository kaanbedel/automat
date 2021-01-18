namespace Automat.Application.Abstraction
{
    public interface IPaymentService
    {
        (string message, bool result) MakePayment(decimal money, decimal totalPrice);
    }
}
