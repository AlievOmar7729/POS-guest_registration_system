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
            if(type == TypePayment.Terminal)
            {
                SetStrategy(new TerminalPayment());
            }
            if(type == TypePayment.Cash)
            {
                SetStrategy(new  CashPayment());
            }
        }
    }
}
