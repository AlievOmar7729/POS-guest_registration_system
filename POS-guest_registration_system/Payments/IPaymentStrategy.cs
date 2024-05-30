using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HotelRoomCreater_Builder_;
using static Payments.PaymentType;

namespace Payments
{
    public interface IPaymentStrategy
    {
        string Pay(Money money, TypePayment type);
    }
}
