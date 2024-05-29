using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelRoomCreater_Builder_
{
    public class HotelRoomDetails
    {
        public bool IsBooked { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public Money PricePerNight { get; set; }
        public bool PetPermit { get; set; }
        public List<Amenity>? Amenities { get; set; }



        public enum Amenity
        {
            Wifi,
            TV,
            AirConditioning,
            MiniBar,
            Safe,
            Breakfast
        }


        public string ShowDetails()
        {
            var details = new StringBuilder();

            details.AppendLine($"Зайнято: {(IsBooked ? "Так" : "Ні")}");
            details.AppendLine($"Номер кімнати: {RoomNumber}");
            details.AppendLine($"Номер поверху: {FloorNumber}");
            details.AppendLine($"Ціна за ніч: {PricePerNight.Amount} {PricePerNight.Currency.Symbol}.");
            details.AppendLine($"З тваринами: {(PetPermit ? "Дозволено" : "Заборонено")}");
            details.Append(DisplayAmenities(Amenities));

            return details.ToString();
        }

        private string DisplayAmenities(List<Amenity> amenities)
        {

            if (amenities == null || amenities.Count == 0)
            {
                return "У номері відсутні додаткові зручності";
            }
            else
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine("Зручності:");
                foreach (var amenity in amenities)
                {
                    result.AppendLine($"   {GetAmenityDescription(amenity)}");
                }
                return result.ToString();
            }
        }


        private string GetAmenityDescription(Amenity amenity)
        {
            return amenity switch
            {
                Amenity.Wifi => "Wi-Fi",
                Amenity.TV => "Телевізор",
                Amenity.AirConditioning => "Кондиціонер",
                Amenity.MiniBar => "Міні бар",
                Amenity.Safe => "Сейф",
                Amenity.Breakfast => "Сніданок",
                _ => amenity.ToString()
            };
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }




}
