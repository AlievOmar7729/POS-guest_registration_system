using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HotelRoomCreater_Builder_.HotelRoomDetails;

namespace HotelRoomCreater_Builder_
{
    public class HotelRoomBuilder : IBuilderHotelRoomDetails
    {
        private HotelRoomDetails hotelRoomDetails;

        public HotelRoomBuilder()
        {
            hotelRoomDetails = new HotelRoomDetails();
            hotelRoomDetails.Amenities = new List<Amenity>();
        }


        public IBuilderHotelRoomDetails SetAmenities(Amenity amenities)
        {
            hotelRoomDetails.Amenities.Add(amenities);
            return this;
        }

        public IBuilderHotelRoomDetails SetFloorNumber(int floorNumber)
        {
            hotelRoomDetails.FloorNumber = floorNumber;
            return this;
        }

        public IBuilderHotelRoomDetails SetIsBooked(bool isBooked)
        {
            hotelRoomDetails.IsBooked = isBooked;
            return this;
        }

        public IBuilderHotelRoomDetails SetPetPermit(bool petPermit)
        {
            hotelRoomDetails.PetPermit = petPermit;
            return this;
        }

        public IBuilderHotelRoomDetails SetPricePerNight(Money pricePerNight)
        {
            hotelRoomDetails.PricePerNight = pricePerNight;
            return this;
        }

        public IBuilderHotelRoomDetails SetRoomNumber(int roomNumber)
        {
            hotelRoomDetails.RoomNumber = roomNumber;
            return this;
        }


        public HotelRoomDetails Create()
        {
            return hotelRoomDetails;
        }
    }
}
