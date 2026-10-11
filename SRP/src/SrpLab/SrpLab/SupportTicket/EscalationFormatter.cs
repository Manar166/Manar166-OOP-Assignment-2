using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SupportTicket
{
    public class EscalationFormatter
    {
        public string InternalEscalationBlurb( string ticketId,
        string priority,
        DateTimeOffset deadline)
        {
            return $"ESCALATE {ticketId} priority={priority} breachAt={deadline:u} keywords-scanned=yes";
        }
    }
}
