using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomCreater_Builder_
{
    public class HotelRoomDirector
    {
        private readonly IBuilderHotelRoomDetails _create;

        public HotelRoomDirector(IBuilderHotelRoomDetails create)
        {
            _create = create;
        }
        public HotelRoomDetails CreateDetails()
        {
            return _create.Create();
        }
    }
}
