using Guest_Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_Singleton_
{
    public interface ITotalCostCalculator
    {
        int CalculateStayDuration(Guest guest);
    }
}
