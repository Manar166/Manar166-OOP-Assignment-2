using SwiftBite.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liberary.Bussniess
{
    public class Dvd : LibraryItem
    {
        protected Dvd(string title, double BaseLateFeePerDay) 
        : base(title, loanPeriodDays:7, baseLateFeePerDay: BaseLateFeePerDay)
        {
        }


        public static Dvd Create( string title, double baseLateFeePerDay)
        {
            Guard.NotEmpty(title, nameof(title));
            Guard.Against(baseLateFeePerDay < 0, $"{nameof(baseLateFeePerDay)} cannot be negative");

            return new Dvd( title, baseLateFeePerDay);
        }

        public new double GetDailyLateFee() => BaseLateFeePerDay * 2;
    }
}
