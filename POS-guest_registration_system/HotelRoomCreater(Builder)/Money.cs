using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomCreater_Builder_
{
    public class Money : IMoney , ISetAmmountMoney
    {
        private Currency currency;
        public Currency Currency => currency;
        public int Whole { get; private set; }
        public int Fractions { get; private set; }
        public decimal Amount { get => Whole + Fractions / 100m; }

        public Money(int whole, int fractional, Currency currency)
        {
            if (whole < 0)
            {
                throw new ArgumentException("Whole part cannot has value less than 0", nameof(whole));
            }

            if (fractional < 0 || fractional > 99)
            {
                throw new ArgumentException("Fractional part can only has values from 0 to 99", nameof(fractional));
            }

            Whole = whole;
            Fractions = fractional;
            this.currency = currency;
        }

        public void SetAmount(int whole, int fractions)
        {
            Whole = whole;
            Fractions = fractions;
        }
    }
}
