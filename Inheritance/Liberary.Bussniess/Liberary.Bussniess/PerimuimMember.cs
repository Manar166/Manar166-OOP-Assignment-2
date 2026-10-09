using SwiftBite.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liberary.Bussniess
{
    public  class PerimuimMember:Member
    {
        private int _points=0;
        

        private PerimuimMember(string fullName,string phoneNumber,double discountPrecent)
            :base(fullName,phoneNumber,maxLoan:10,discountPrecent)
        {

            
        }

        public static PerimuimMember Create(string fullName, string phoneNimber, double discountPrecent)
        {
            Guard.NotEmpty(fullName, "Full Naame");
            Guard.NotEmpty(phoneNimber, "PhoneNumber");
            Guard.Against(discountPrecent <= 0, $"{discountPrecent} can not be <=0");
            return new(fullName, phoneNimber, discountPrecent);

        }

        public void EarnPointsForReturn() => _points += 5;
        public int GetTotalPoints() => _points;



    }
}
