using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.GradeBookClasses
{
    public class GradePolicy
    {
        

        public string Letter(decimal avg)
        {
            // Academic policy bands change with faculty senate — not with CSV layout.
           
            if (avg >= 90) return "A";
            if (avg >= 80) return "B";
            if (avg >= 70) return "C";
            if (avg >= 60) return "D";
            return "F";
        }
    }
}
