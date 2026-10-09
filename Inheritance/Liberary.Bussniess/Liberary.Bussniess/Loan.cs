using SwiftBite.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liberary.Bussniess
{
    public class Loan
    {
        private static int _nextId=1;
        public int LoanId { get; }
        public DateTime BorrowDate { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnDate { get; private set; }
        public LoanStatus Status { get; private set; }
        public Member Member { get; }
        public LibraryItem Item { get; }
        public double CalculatedLateFee { get; private set; }


        public Loan( DateTime borrowDate, Member member, LibraryItem item)
        {
            Guard.Against(member == null, nameof(member));
            Guard.Against(item == null, nameof(item));
            Guard.Against(member == null, "member is null");
            Guard.Against(item == null, "item is null");

            LoanId = _nextId++;
            BorrowDate = borrowDate;
            Member = member!;
            Item = item!;

           
            DueDate = borrowDate.AddDays(item.LoanPeriodDays);

            Status = LoanStatus.Borrowed;
            CalculatedLateFee = 0.0;

            Item.MarkAsBorrowed();
        }

        public void ReturnLoan(DateTime date)
        {
            Guard.Against(Status == LoanStatus.Returned, " Returned Item already ");
            Guard.Against(Status != LoanStatus.Borrowed, "no borrowed Loan");
            Guard.Against(date < ReturnDate, "wrong date ");
            if (Member is PerimuimMember perimuimMember)
            {
                perimuimMember.EarnPointsForReturn();
            }
            Status = LoanStatus.Returned;
            ReturnDate = date;
            Item.MarkAsReturned() ;


        }

        public void MarkAsLost()
        {
            Guard.Against(Status == LoanStatus.Returned, "Can Not Mark Returned Item as Lost");

            Status = LoanStatus.Lost;
            Item.Withdraw();
        }

 

        public double CalculateLateFee(DateTime returnDate)
        {
       
            if (returnDate <= DueDate)
                return 0.0;

            int lateDays = (returnDate - DueDate).Days;

            double dailyFee = Item switch
            {
                Dvd dvd => dvd.GetDailyLateFee(),
                Magazine magazine => magazine.GetDailyLateFee(),
                _ => Item.GetDailyLateFee()
            };
         

           
            double fees = lateDays * dailyFee;

            
            double discount = fees * (Member.DiscountPrecentage / 100.0);

          
            return fees - discount;
        }


    }
}
