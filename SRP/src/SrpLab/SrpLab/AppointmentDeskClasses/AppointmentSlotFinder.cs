using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.AppointmentDeskClasses
{
    public class AppointmentSlotFinder
    {
        private AppointmentDesk appointmentDesk;
        private AppointmentSchedule appointmentSchedule;
        private BusinessHoursPolicy businessHoursPolicy;

       
     

        public AppointmentSlotFinder(AppointmentDesk appointmentDesk, AppointmentSchedule appointmentSchedule, BusinessHoursPolicy businessHoursPolicy)
        {
            this.appointmentDesk = appointmentDesk;
            this.appointmentSchedule = appointmentSchedule;
            this.businessHoursPolicy = businessHoursPolicy;
        }

        public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
        {
            var cursor = appointmentDesk.Align(from);
            var end = from.AddHours(searchHours);
            while (cursor < end)
            {
                if (businessHoursPolicy.IsWithinBusinessHours(cursor) && !appointmentSchedule.Booked.Contains(cursor))
                    return cursor;
                cursor = cursor.AddMinutes(appointmentDesk.SlotMinutes);
            }
            return null;
        }
    }
}
