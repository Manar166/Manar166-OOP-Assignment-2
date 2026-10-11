using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CourseEnrollmentClasses
{
    public class WelcomePacketGenerator
    {
        private readonly Course course;
        private readonly EnrollmentManger enrollmentManger;

        public WelcomePacketGenerator(Course course, EnrollmentManger enrollmentManger)
        {
            this.course = course;
            this.enrollmentManger = enrollmentManger;
        }

        public string WelcomePacketMarkdown(string studentEmail, string studentName)
        {
            // Content design changes with academy marketing — not with seat algorithms.
            var status = enrollmentManger.Seated.Contains(studentEmail) ? "confirmed seat" : $"waitlist #{enrollmentManger.WaitlistPosition(studentEmail)}";
            return $"# Welcome to {course.CourseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
                   $"Bring a laptop. Discord onboarding link: https://example.invalid/{course.CourseCode.ToLowerInvariant()}\n";
        }
    }
}
