using Guest_Singleton_;

namespace Guest_Singleton
{
    public sealed class Guest
    {
        private static Guest instance;
        private static readonly object lockObject = new object();

        public string Name { get; set; }
        public string PassportNumber { set; private get; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        private Guest() { }

        public static Guest Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Guest();
                    }
                    return instance;
                }
            }
        }

        public static void SetGuestInfo(string name, string passportNumber, DateTime checkOutDate)
        {
            var guest = Instance;
            guest.Name = name;
            guest.PassportNumber = passportNumber;
            guest.CheckInDate = DateTime.Now.Date;
            guest.CheckOutDate = checkOutDate.Date;
        }

        public void ClearInstance()
        {
            Name = null;
            PassportNumber = null;
            CheckInDate = DateTime.MinValue;
            CheckOutDate = DateTime.MinValue;
        }
    }
}