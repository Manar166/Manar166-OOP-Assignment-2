using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.GradeBookClasses
{
    public class HonorRollEvaluator
    {
        private readonly GradePolicy _gradePolicy;

        public HonorRollEvaluator(GradePolicy gradePolicy)
        {
            _gradePolicy = gradePolicy;
        }

        public bool MeetsHonorRoll(decimal avg)
        {
          
            return avg >= 85 && (_gradePolicy.Letter(avg) is "A" or "B");
        }
    }
}
