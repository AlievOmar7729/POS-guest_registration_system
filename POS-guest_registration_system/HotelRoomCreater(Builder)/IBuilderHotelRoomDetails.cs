using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelRoomCreater_Builder_.HotelRoomDetails;

namespace HotelRoomCreater_Builder_
{
    public interface IBuilderHotelRoomDetails
    {
        IBuilderHotelRoomDetails SetIsBooked(bool isBooked);
        IBuilderHotelRoomDetails SetRoomNumber(int roomNumber);
        IBuilderHotelRoomDetails SetFloorNumber(int floorNumber);
        IBuilderHotelRoomDetails SetPricePerNight(Money pricePerNight);
        IBuilderHotelRoomDetails SetPetPermit(bool petPermit);
        IBuilderHotelRoomDetails SetAmenities(Amenity amenities);

        HotelRoomDetails Create();

    }
}
