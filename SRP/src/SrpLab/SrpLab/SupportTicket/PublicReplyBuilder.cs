using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SupportTicket
{
    public class PublicReplyBuilder
    {
        public string DraftPublicReply(string ticketId,
        string priority,
        string agentName,
        DateTimeOffset deadline)
        {
            // Tone/templates owned by CX — not by SLA engineering.
            var apology = priority == "P1" ? "We are treating this as a critical incident." : "Thanks for reaching out.";
            return $"Hi,\n{apology}\nTicket {ticketId} is with {agentName}. Next update before {deadline:u}.\n";
        }
    }
}
