using System;
using System.Collections.Generic;
using System.Text;

namespace PatternsLab.Builder
{
    public class CourseRegistration
    {
        public string StudentEmail { get; }
        public string CourseCode { get; }
        public string AccessMode { get; }
        public string? GroupCode { get; }
        public string? DiscountCode { get; }
        public bool SendWhatsApp { get; }
        public bool SendEmailWelcome { get; }
        public string? MentorNote { get; }
        public DateOnly? PreferredStart { get; }

        private CourseRegistration(
            string studentEmail,
            string courseCode,
            string accessMode,
            string? groupCode,
            string? discountCode,
            bool sendWhatsApp,
            bool sendEmailWelcome,
            string? mentorNote,
            DateOnly? preferredStart)
        {
           
           


            StudentEmail = studentEmail;
            CourseCode = courseCode;
            AccessMode = accessMode;
            GroupCode = groupCode;
            DiscountCode = discountCode;
            SendWhatsApp = sendWhatsApp;
            SendEmailWelcome = sendEmailWelcome;
            MentorNote = mentorNote;
            PreferredStart = preferredStart;
        }

        public override string ToString()
            => $"{StudentEmail} → {CourseCode} [{AccessMode}] group={GroupCode ?? "-"} discount={DiscountCode ?? "-"} wa={SendWhatsApp} mail={SendEmailWelcome}";


        public class Builder
        {    private string? studentEmail;
            private string? courseCode;
            private string accessMode ;
            private string? groupCode;

            private string? discountCode;
            private bool sendWhatsApp = false;
            private bool sendEmailWelcome = false;
            private string? mentorNote;
            private DateOnly? preferredStart;

            public Builder(string? studentEmail, string? courseCode)
            {
                if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
                if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");
                this.studentEmail = studentEmail;
                this.courseCode = courseCode;
            }

            public Builder SetAccessMode(string accessMode)
            {
                this.accessMode = accessMode;
                return this;
            }

            public Builder SetGroupCode(string GC)
            {
                groupCode = GC;
                return this;
            }

            public Builder WithDiscountCode(string discountCode)
            {
                this.discountCode = discountCode;
                return this;
            }

            public Builder SendWhatsApp(bool sendWhats)
            {
                sendWhatsApp = sendWhats;
                return this;
            }

            public Builder SendEmailWelcome(bool sendEmail)
            {
                sendEmailWelcome = sendEmail;
                return this;
            }

            public Builder SetMentorNotes(string? mentorNote)
            {
                mentorNote = mentorNote;
                return this;
            }

            public Builder SetPreferredStart(DateOnly preferredStart)
            {
                this.preferredStart = preferredStart;
                return this;
            }

            public CourseRegistration Build()
            {

                if (accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(groupCode))
                    throw new InvalidOperationException("LiveGroup requires GroupCode");
                if (accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(groupCode))
                    throw new InvalidOperationException("VideosOnly cannot have GroupCode");


                      return new CourseRegistration(studentEmail, courseCode, accessMode
                    , groupCode, discountCode, sendWhatsApp, sendEmailWelcome, mentorNote, preferredStart);
            
            }
        }


    }

    public static class RegistrationCallSites
    {
        public static CourseRegistration CreateLiveStudent()
        {
            return new CourseRegistration.Builder("sara@mail.com", "SEF-101").SetAccessMode("LiveGroup")
                    .SetGroupCode("G1").WithDiscountCode("EARLY10").SendEmailWelcome(true).SendWhatsApp(true)
                    .SetMentorNotes("Needs evening slot").SetPreferredStart(new DateOnly(2026, 10, 1)).Build();
        }

        public static CourseRegistration CreateVideosOnly()
        {
            return new CourseRegistration.Builder("sara@mail.com", "SEF-101").SetAccessMode("VideoOnly")
                   .SendEmailWelcome(true).SendWhatsApp(false)
                    .Build();
        }
    }

}

