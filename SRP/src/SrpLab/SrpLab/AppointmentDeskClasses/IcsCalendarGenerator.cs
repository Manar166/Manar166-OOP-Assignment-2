using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.AppointmentDeskClasses
{
    public class IcsCalendarGenerator
    {
        public string ToIcs(DateTimeOffset slot, string patientName, string clinician, int SlotMinutes)
        {
            // Calendar interoperability format changes with clients — not opening hours.
            var uid = Guid.NewGuid();
            var end = slot.AddMinutes(SlotMinutes);
            return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
                   $"UID:{uid}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
                   $"SUMMARY:Visit {patientName} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
        }
    }
}
