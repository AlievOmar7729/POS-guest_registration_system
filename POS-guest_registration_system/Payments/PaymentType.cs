using HotelRoomCreater_Builder_;

namespace Payments
{
    public class PaymentType
    {
        private IPaymentStrategy _strategy;
        public enum TypePayment
        {
            Cash,
            Terminal
        }


        private void SetStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }

        public void Pay(TypePayment type)
        {
            switch (type)
            {
                case TypePayment.Terminal:
                    SetStrategy(new TerminalPayment());
                    break;
                case TypePayment.Cash:
                    SetStrategy(new CashPayment());
                    break;
                default:
                    throw new ArgumentException("Invalid payment type specified.");
            }
        }
    }
}
