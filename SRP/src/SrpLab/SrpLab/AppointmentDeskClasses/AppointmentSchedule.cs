using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.AppointmentDeskClasses
{
    public class AppointmentSchedule
    {
        private readonly HashSet<DateTimeOffset> _booked = new();
        public IReadOnlySet<DateTimeOffset> Booked => _booked;
        BusinessHoursPolicy businessHoursPolicy;

        public AppointmentSchedule(BusinessHoursPolicy businessHoursPolicy)
        {
            this.businessHoursPolicy = businessHoursPolicy;
        }

        public bool TryBook(DateTimeOffset slot )
        {
            if (!businessHoursPolicy.IsWithinBusinessHours(slot) || _booked.Contains(slot)) return false;
            _booked.Add(slot);
            return true;
        }
    }
}
