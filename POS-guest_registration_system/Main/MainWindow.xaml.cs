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
        Guest guest = Guest.Instance;
        IBuilderHotelRoomDetails builder = new HotelRoomBuilder();
        HotelRoomDetails f1n1;
        

        public MainWindow()
        {
            InitializeComponent();
            f1n1 = builder.SetIsBooked(false).
               SetRoomNumber(1).
               SetFloorNumber(1).
               SetPricePerNight(new Money(50, 20, new Currency("USD"))).
               SetPetPermit(true).
               SetAmenities(Amenity.TV).
               SetAmenities(Amenity.Wifi).
               Create();



        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {


            Guest.SetGuestInfo("Omar", "11010111", dat.SelectedDate.Value);
            PriceCalculator calculator = new PriceCalculator();
            Money s = calculator.CalculateCostStay(guest, f1n1);

            tex.Text = s.ToString();    
            


        }


    }
}