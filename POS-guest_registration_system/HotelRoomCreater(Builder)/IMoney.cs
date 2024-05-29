using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomCreater_Builder_
{
    public interface IMoney
    {
        public int Whole { get; }
        public int Fractions { get; }
        public decimal Amount { get; }
    }
}
