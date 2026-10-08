using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SupportTicket
{
    internal class SlaCalculator
    {
        public DateTimeOffset OpenedAt { get; }
        public string Priority { get; private set; } = "P3";
        public DateTimeOffset SlaDeadline()
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

        public bool IsBreached(DateTimeOffset now) => now > SlaDeadline();

    }
}
