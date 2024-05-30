using HotelRoomCreater_Builder_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Payments.PaymentType;

namespace Payments
{
    public class CashPayment : IPaymentStrategy
    {
        public string Pay(Money money, TypePayment type)
        {
            try
            {
                CashDrawerLibrary.OpenDrawer();
                return "Оплата здійснена готівкою";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
