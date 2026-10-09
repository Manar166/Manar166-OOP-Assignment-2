using SwiftBite.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liberary.Bussniess
{
    public class Magazine : LibraryItem
    {
        protected Magazine(string title, double baseLateFeePerDay) 
            : base(title, loanPeriodDays:3, baseLateFeePerDay)
        {
        }

        public static Magazine Create( string title, double baseLateFeePerDay)
        {
            Guard.NotEmpty(title, nameof(title));
            Guard.Against(baseLateFeePerDay < 0, $"{nameof(baseLateFeePerDay)} cannot be negative");

            return new Magazine(title, baseLateFeePerDay);
        }

        public new double GetDailyLateFee() =>  0.5 * BaseLateFeePerDay;
    }
}
