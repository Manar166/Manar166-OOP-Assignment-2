using SwiftBite.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liberary.Bussniess
{
    public class StudentMember : Member
    {

        private StudentMember(string fullName, string phoneNumber)
            : base(fullName, phoneNumber, maxLoan:3,discountPrecent:0)
        {
           

        }

        public static StudentMember Create(string fullName, string phoneNimber)
        {
            Guard.NotEmpty(fullName, "Full Naame");
            Guard.NotEmpty(phoneNimber, "PhoneNumber");
            return new(fullName, phoneNimber);

        }

  



    }
}
