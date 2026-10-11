using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SupportTicket
{
    public class SlaCalculator
    {
       
        
        public DateTimeOffset SlaDeadline(string Priority, DateTimeOffset OpenedAt)
        {
            // Operational SLA policy — different stakeholders than reply wording.
            var hours = Priority switch
            {
                "P1" => 4,
                "P2" => 24,
                _ => 72
            };
            return OpenedAt.AddHours(hours);
        }

        public bool IsBreached(DateTimeOffset now,string Priority, DateTimeOffset OpenedAt) => now > SlaDeadline(Priority, OpenedAt);

    }
}
