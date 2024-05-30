using HotelRoomCreater_Builder_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Payments.PaymentType;

namespace Payments
{
    public class TerminalPayment : IPaymentStrategy
    {
        public string Pay(Money money, TypePayment type)
        {
            try
            {
                PaymentTerminalLibrary.SendPayment(money);
                return "Оплата здійснена терміналом";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
