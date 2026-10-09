using SwiftBite.Common;
using System;

namespace Liberary.Bussniess
{
    public class LibraryItem
    {
        public static int _nextId = 1;
        public int CatalogNumber { get; }
        public string Title { get; }
        public bool IsOnLoan { get; internal set; }
        public bool IsWithdrawn { get; private set; }
        public double BaseLateFeePerDay { get; protected set; }
        public int LoanPeriodDays { get; }

        
        protected LibraryItem( string title, int loanPeriodDays, double baseLateFeePerDay)
        {
            Guard.NotEmpty(title, nameof(title));
            Guard.Against(loanPeriodDays <= 0, $"{nameof(loanPeriodDays)} must be greater than zero");
            Guard.Against(baseLateFeePerDay < 0, $"{nameof(baseLateFeePerDay)} cannot be negative");

            CatalogNumber = _nextId++;
            Title = title;
            LoanPeriodDays = loanPeriodDays;
            BaseLateFeePerDay = baseLateFeePerDay;

            IsOnLoan = false;
            IsWithdrawn = false;
        }

        public void MarkAsBorrowed()
        {
            Guard.Against(IsOnLoan, "This item is already loaned");
            Guard.Against(IsWithdrawn, "This item is withdrawn");
            IsOnLoan = true;
        }

        public void MarkAsReturned()
        {
            Guard.Against(!IsOnLoan, "This item is not currently loaned");
            IsOnLoan = false;
        }

        public void Withdraw()
        {
            Guard.Against(IsOnLoan, "Cannot withdraw an item that is currently loaned");
            IsWithdrawn = true;
        }

        public void Restore()
        {
            IsWithdrawn = false;
        }

        public double GetDailyLateFee() => BaseLateFeePerDay;

        public void UpdateBaseFee(double newFee)
        {
            Guard.Against(newFee < 0, $"{nameof(newFee)} cannot be negative");
            BaseLateFeePerDay = newFee;
        }


    }
}