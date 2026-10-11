using SwiftBite.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liberary.Bussniess
{
    public class Shelver:Staff
    {
        public string Section { get; private set; }
        private Shelver(string fullName, string phoneNumber, DateTime hireDate, double monthlySalary,string initialSection)
            : base(fullName, phoneNumber, hireDate, monthlySalary)
        {
            Section = initialSection;

        }
        public static Shelver Create(string fullName, string phoneNumber, DateTime hireDate, double monthlySalary, string initialSection)
        {
            Guard.NotEmpty(initialSection, "initial section");
            return new(fullName, phoneNumber, hireDate, monthlySalary, initialSection);


        }

        public void ReAssignSection(string newSection)
        {
            Guard.NotEmpty(newSection, "new section");
            Section = newSection;
        }

       

    }
}
