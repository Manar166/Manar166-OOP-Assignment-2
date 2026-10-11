using SwiftBite.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liberary.Bussniess
{
    public class Book : LibraryItem
    {
        private Book(string title, double baseLateFeePerDay) 
            : base(title, loanPeriodDays:21, baseLateFeePerDay)
        {
        }

        public static Book Create( string title, double baseLateFeePerDay)
        {
            Guard.NotEmpty(title, nameof(title));
            Guard.Against(baseLateFeePerDay < 0, $"{nameof(baseLateFeePerDay)} cannot be negative");

            return new Book( title, baseLateFeePerDay);
        }


    }
}
