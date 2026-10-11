using System;
using System.Collections.Generic;
using System.Text;

namespace Liberary.Bussniess
{
    public class HeadLiberarian : Staff
    {
        private const double ResponsibilityAllowance = 400.0;
        private HeadLiberarian(string fullName, string phoneNumber, DateTime hireDate, double monthlySalary) 
            : base(fullName, phoneNumber, hireDate, monthlySalary)
        {

        }

        public static HeadLiberarian Create(string fullName, string phoneNumber, DateTime hireDate, double monthlySalary)
        {
            return new(fullName, phoneNumber, hireDate, monthlySalary);
        }

        public void ChangeLateFeePrice(LibraryItem item ,double newFee)
        {
            item.UpdateBaseFee(newFee);
        }

        public new double GetMonthlyPay()
        {
            return MonthlySalary + ResponsibilityAllowance;
        }

        public void RestoreItem(LibraryItem item)
        {

            item.Restore();

        }

        public void WithdrawItem(LibraryItem item)
        {
            item.Withdraw();
        
        }

    }
}
