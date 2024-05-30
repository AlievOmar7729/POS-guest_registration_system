using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_Singleton_
{
    public interface IGuest
    {
        string Name { get; set; }
        string PassportNumber { set; }
        DateTime CheckInDate { get; set; }
        DateTime CheckOutDate { get; set; }
    }
}
