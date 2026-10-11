using SwiftBite.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Liberary.Bussniess
{
    public class Staff:Person
    {
      

        public DateTime HireDate { get; }

        public double MonthlySalary { get; private set; }
        protected Staff(string fullName, string phoneNumber, DateTime hireDate, double monthlySalary) : base(fullName, phoneNumber)
        {
            Guard.NotEmpty(fullName, "Full Naame");
            Guard.NotEmpty(phoneNumber, "PhoneNumber");
            Guard.Against(hireDate > DateTime.Now, "hire date cannot be future date");
            Guard.Against(monthlySalary <= 0, "salary can not be <0");
            HireDate = hireDate;
            MonthlySalary = monthlySalary;
        }

        //public static Staff Create(string fullName, string phoneNumber, DateTime hireDate, double monthlySalary)
        //{
           
        //    return new(fullName, phoneNumber, hireDate, monthlySalary);
        //}

        public void GiveRaise(double precentage)
        {
            Guard.Against(precentage < 0, "precentage can not be <0");

            MonthlySalary *= precentage/100.0;

        }

        public double GetMonthlyPay() => MonthlySalary;



    }
}
