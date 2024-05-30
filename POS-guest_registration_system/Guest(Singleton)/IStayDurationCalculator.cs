using Guest_Singleton;
using HotelRoomCreater_Builder_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_Singleton_
{
    public interface IStayDurationCalculator
    {
        public Money CalculateCostStay(Guest guest,HotelRoomDetails hotel);
    }
}
