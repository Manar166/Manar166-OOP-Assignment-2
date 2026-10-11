using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CourseEnrollmentClasses
{
    public  class TuitionInvoiceGenerator
    {
        private readonly Course course;
        private readonly EnrollmentManger enrollmentManger;

        

        public TuitionInvoiceGenerator(Course course, EnrollmentManger enrollmentManger)
        {
            this.course = course;
            this.enrollmentManger = enrollmentManger;
        }

        public string TuitionInvoiceLine(string studentEmail)
        {
            // Finance formatting / tax later — separate from enrollment capacity.
            if (!enrollmentManger.Seated.Contains(studentEmail)) return $"{course.CourseCode},WAITLIST,0.00";
            var vat = Math.Round(course.Tuition * 0.14m, 2);
            return $"{course.CourseCode},TUITION,{course.Tuition:0.00},VAT,{vat:0.00},TOTAL,{(course.Tuition + vat):0.00}";
        }
    }
}
