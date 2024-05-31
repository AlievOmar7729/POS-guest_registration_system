using Guest_Singleton;
using HotelRoomCreater_Builder_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_Singleton_
{
    public class PriceCalculator : IStayDurationCalculator, ITotalCostCalculator
    {
        public  Money CalculateCostStay(Guest guest, HotelRoomDetails hotel)
        {

            int count_day = CalculateStayDuration(guest);
            
            decimal totalCost = count_day * hotel.PricePerNight.Amount;
            int whole = (int)Math.Floor(totalCost);
            int fractions = (int)((totalCost - whole) * 100);

            return new Money(whole,fractions,hotel.PricePerNight.Currency);
        }

        public int CalculateStayDuration(Guest guest)
        {
            int stayDuration = (int)(guest.CheckOutDate - guest.CheckInDate).TotalDays;
            return stayDuration;
        }

      




    }
}
