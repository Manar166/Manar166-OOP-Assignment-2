using SwiftBite.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liberary.Bussniess
{
    public class Liberarian:Staff
    {
        private Liberarian(string fullName, string phoneNumber, DateTime hireDate, double monthlySalary)
            :base(fullName, phoneNumber, hireDate, monthlySalary)
        {
            
        }


        public static Liberarian Create(string fullName, string phoneNumber, DateTime hireDate, double monthlySalary)
        {
            return new(fullName, phoneNumber, hireDate, monthlySalary);
        }

        public void ProcessReturn(Loan loan, DateTime returnDate)
        {
            Guard.Against(loan is null, "loan doesnot exist");
            loan.ReturnLoan(returnDate);
        }

        public void MarkItemLost(Loan loan)
        {
            Guard.Against(loan == null, nameof(loan));
            loan.MarkAsLost();
        }

    }
}
