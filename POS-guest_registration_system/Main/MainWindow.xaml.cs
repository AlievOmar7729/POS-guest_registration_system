using Guest_Singleton;
using Guest_Singleton_;
using HotelRoomCreater_Builder_;
using Payments;
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
using static Payments.PaymentType;

namespace Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        Guest guest = Guest.Instance;
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
            DataOutDatePicker.SelectedDate = DateTime.Now.AddDays(1);
            DataOutDatePicker.DisplayDateStart = DateTime.Now.AddDays(1);
            f1n1 = new HotelRoomBuilder()
                       .SetIsBooked(false)
                       .SetRoomNumber(1)
                       .SetFloorNumber(1)
                       .SetPricePerNight(new Money(20, 00, new Currency("USD")))
                       .SetPetPermit(true)
                       .SetAmenities(Amenity.TV)
                       .SetAmenities(Amenity.Wifi)
                       .Create();
            rooms.Add(f1n1);

            f1n2 = new HotelRoomBuilder().
               SetIsBooked(true).
               SetRoomNumber(2).
               SetFloorNumber(1).
               SetPricePerNight(new Money(21, 00, new Currency("USD"))).
               SetPetPermit(true).
               SetAmenities(Amenity.TV).
               SetAmenities(Amenity.Wifi).
               Create();
               rooms.Add(f1n2);
            f1n3 = new HotelRoomBuilder().
                SetIsBooked(false).
               SetRoomNumber(3).
               SetFloorNumber(1).
               SetPricePerNight(new Money(20, 00, new Currency("USD"))).
               SetPetPermit(true).
               SetAmenities(Amenity.TV).
               SetAmenities(Amenity.Wifi).
               Create();
            rooms.Add(f1n3);
            f2n4 = new HotelRoomBuilder().
                SetIsBooked(false).
               SetRoomNumber(4).
               SetFloorNumber(2).
               SetPricePerNight(new Money(31, 00, new Currency("USD"))).
               SetPetPermit(true).
               SetAmenities(Amenity.TV).
               SetAmenities(Amenity.Wifi).
               SetAmenities(Amenity.AirConditioning).
               Create();
            rooms.Add(f2n4);
            f2n5 = new HotelRoomBuilder().
                SetIsBooked(false).
               SetRoomNumber(5).
               SetFloorNumber(2).
               SetPricePerNight(new Money(40, 00, new Currency("USD"))).
               SetPetPermit(true).
               SetAmenities(Amenity.TV).
               SetAmenities(Amenity.Wifi).
               SetAmenities(Amenity.MiniBar).
               Create();
            rooms.Add(f2n5);
            f2n6 = new HotelRoomBuilder().
                SetIsBooked(true).
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
            NameGuestTextBox.Text = "";
            PassportNumberTextBox.Text = "";
            DataOutDatePicker.SelectedDate = DateTime.Now.AddDays(1);

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
        public List<HotelRoomDetails> FilterRooms(List<HotelRoomDetails> rooms)
        {
            int selectedFloor = FloorComboBox.SelectedIndex > 0 ? (int)((ComboBoxItem)FloorComboBox.SelectedItem).Content : -1;
            int selectedRoomNumber = RoomNumberComboBox.SelectedIndex > 0 ? (int)((ComboBoxItem)RoomNumberComboBox.SelectedItem).Content : -1;

            bool petPermit = PetCheckBox.IsChecked == true;
            bool airConditioning = AirConditioningCheckBox.IsChecked == true;
            bool tv = TVCheckBox.IsChecked == true;
            bool miniBar = MiniBarCheckBox.IsChecked == true;
            bool safe = SafeCheckBox.IsChecked == true;
            bool breakfast = BreakfastCheckBox.IsChecked == true;
            bool wifi = WiFiCheckBox.IsChecked == true;

            var filteredRooms = rooms.Where(room =>
                (selectedFloor == -1 || room.FloorNumber == selectedFloor) &&
                (selectedRoomNumber == -1 || room.RoomNumber == selectedRoomNumber) &&
                (!petPermit || room.PetPermit) &&
                (!airConditioning || room.Amenities.Contains(Amenity.AirConditioning)) &&
                (!tv || room.Amenities.Contains(Amenity.TV)) &&
                (!miniBar || room.Amenities.Contains(Amenity.MiniBar)) &&
                (!safe || room.Amenities.Contains(Amenity.Safe)) &&
                (!breakfast || room.Amenities.Contains(Amenity.Breakfast)) &&
                (!wifi || room.Amenities.Contains(Amenity.Wifi))
            ).ToList();

            return filteredRooms;
        }


        private void GiveRoom_Click(object sender, RoutedEventArgs e)
        {
            guest.Name = NameGuestTextBox.Text;
            guest.CheckInDate = DateTime.Now;
            guest.CheckOutDate = DataOutDatePicker.SelectedDate.Value;
            guest.PassportNumber = PassportNumberTextBox.Text;

            List<HotelRoomDetails> filerList = FilterRooms(rooms);

            if(filerList.Count > 0 && filerList[0].IsBooked == false)
            {
                filerList[0].IsBooked = true;
                PriceCalculator price = new PriceCalculator();
                Money s = price.CalculateCostStay(guest, filerList[0]);
                MessageBoxResult result = MessageBox.Show($"Вімкнути термінал для оплати {s} ?", "Оплата", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                PaymentType payment = new PaymentType();

                if (result == MessageBoxResult.Yes)
                {
                    payment.Pay(TypePayment.Terminal);
                }
                else if (result == MessageBoxResult.No)
                {
                    payment.Pay(TypePayment.Cash);
                }


            }
            else
            {
                MessageBox.Show($"Наразі номерів по заданих крітеріях немає", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            guest.ClearInstance();
            register.Visibility = Visibility.Hidden;
        }
    }
}