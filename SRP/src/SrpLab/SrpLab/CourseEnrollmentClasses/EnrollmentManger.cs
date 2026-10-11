using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.CourseEnrollmentClasses
{
    public class EnrollmentManger
    {
    private readonly HashSet<string> _seated = new(StringComparer.OrdinalIgnoreCase);
    private readonly List<string> _waitlist = new();

        public HashSet<string> Seated => _seated;
        public IReadOnlyList<string> WaitList => _waitlist;
    private readonly Course course;

        public EnrollmentManger(Course course)
        {
            this.course = course;
        }

        public string Register(string studentEmail)
        {
            if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email");
            var email = studentEmail.Trim();

            if (_seated.Contains(email) ||_waitlist.Contains(email))
                return "ALREADY_REGISTERED";

            if (_seated.Count <course.Capacity)
            {
                _seated.Add(email);
                return "SEATED";
            }

            _waitlist.Add(email);
            return $"WAITLIST:{_waitlist.Count}";
        }

        public int WaitlistPosition(string studentEmail)
        {
            var idx = _waitlist.FindIndex(x => x.Equals(studentEmail, StringComparison.OrdinalIgnoreCase));
            return idx < 0 ? -1 : idx + 1;
        }

        public void PromoteFromWaitlist(int seats)
        {
            // Operational promotion policy mixed with messaging responsibilities above.
            while (seats > 0 && _waitlist.Count > 0 && _seated.Count < course.Capacity)
            {
                var next = _waitlist[0];
                _waitlist.RemoveAt(0);
                _seated.Add(next);
                seats--;
            }
        }

    }
}
