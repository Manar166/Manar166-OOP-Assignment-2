using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.AppointmentDeskClasses
{
    public class BusinessHoursPolicy
    {
        private AppointmentDesk appointmentDesk;

        public BusinessHoursPolicy(AppointmentDesk appointmentDesk)
        {
            this.appointmentDesk = appointmentDesk;
        }

        public bool IsWithinBusinessHours(DateTimeOffset when)
        {
            // Clinic calendar policy — HR/ops — not the same as ICS serialization.
            if (when.DayOfWeek is DayOfWeek.Friday or DayOfWeek.Saturday) return false;
            var t = TimeOnly.FromDateTime(when.DateTime);
            return t >= appointmentDesk.Open && t.AddMinutes(appointmentDesk.SlotMinutes) <= appointmentDesk.Close;
        }
    }
}
