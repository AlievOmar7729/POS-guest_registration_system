using Guest_Singleton;
using Guest_Singleton_;
using HotelRoomCreater_Builder_;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static HotelRoomCreater_Builder_.HotelRoomDetails;

namespace Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        IBuilderHotelRoomDetails builder = new HotelRoomBuilder();
        HotelRoomDetails f1n1;
        HotelRoomDetails f1n2;
        HotelRoomDetails f1n3;
        HotelRoomDetails f2n4;
        HotelRoomDetails f2n5;
        HotelRoomDetails f2n6;

        List<HotelRoomDetails> rooms = new List<HotelRoomDetails>();
        public MainWindow()
        {
            InitializeComponent();

            f1n1 = builder.SetIsBooked(false).
               SetRoomNumber(1).
               SetFloorNumber(1).
               SetPricePerNight(new Money(20, 00, new Currency("USD"))).
               SetPetPermit(true).
               SetAmenities(Amenity.TV).
               SetAmenities(Amenity.Wifi).
               Create();
            rooms.Add(f1n1);

            f1n2 = builder.SetIsBooked(true).
               SetRoomNumber(2).
               SetFloorNumber(1).
               SetPricePerNight(new Money(21, 00, new Currency("USD"))).
               SetPetPermit(true).
               SetAmenities(Amenity.TV).
               SetAmenities(Amenity.Wifi).
               Create();
               rooms.Add(f1n2);
            f1n3 = builder.SetIsBooked(false).
               SetRoomNumber(3).
               SetFloorNumber(1).
               SetPricePerNight(new Money(20, 00, new Currency("USD"))).
               SetPetPermit(true).
               SetAmenities(Amenity.TV).
               SetAmenities(Amenity.Wifi).
               Create();
            rooms.Add(f1n3);
            f2n4 = builder.SetIsBooked(false).
               SetRoomNumber(4).
               SetFloorNumber(2).
               SetPricePerNight(new Money(31, 00, new Currency("USD"))).
               SetPetPermit(true).
               SetAmenities(Amenity.TV).
               SetAmenities(Amenity.Wifi).
               SetAmenities(Amenity.AirConditioning).
               Create();
            rooms.Add(f2n4);
            f2n5 = builder.SetIsBooked(false).
               SetRoomNumber(5).
               SetFloorNumber(2).
               SetPricePerNight(new Money(40, 00, new Currency("USD"))).
               SetPetPermit(true).
               SetAmenities(Amenity.TV).
               SetAmenities(Amenity.Wifi).
               SetAmenities(Amenity.MiniBar).
               Create();
            rooms.Add(f2n5);
            f2n6 = builder.SetIsBooked(true).
               SetRoomNumber(6).
               SetFloorNumber(2).
               SetPricePerNight(new Money(10, 50, new Currency("USD"))).
               SetPetPermit(false).
               SetAmenities(Amenity.Wifi).
               Create();
            rooms.Add(f2n6);

            AddItemsToFloorComboBox();
            AddItemsToRoomComboBox();







        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
           register.Visibility = Visibility.Visible;
           freeRoom.Visibility = Visibility.Hidden;
        }

        private void FreeRooms_Click(object sender, RoutedEventArgs e)
        {
            freeRoom.Visibility = Visibility.Visible;
            register.Visibility = Visibility.Hidden;
        }



        private void AddItemsToFloorComboBox()
        {
            FloorComboBox.Items.Add(new ComboBoxItem { Content = "Усі" });
            for (int i = 1; i <= 5; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                FloorComboBox.Items.Add(item);
            }
        }
        private void AddItemsToRoomComboBox()
        {
            RoomNumberComboBox.Items.Add(new ComboBoxItem { Content = "Усі" });
            for (int i = 1; i <= 50; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                RoomNumberComboBox.Items.Add(item);
            }
        }


    }
}