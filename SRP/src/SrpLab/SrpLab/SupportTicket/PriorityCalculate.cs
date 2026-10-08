using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SupportTicket
{
    public class PriorityCalculate
    {
        public PriorityCalculate(SupportTickets ticket, SlaCalculator slaCalculator)
        {
            Ticket = ticket;
            SlaCalculator = slaCalculator;
        }

        public SupportTickets Ticket { get; }
        public SlaCalculator SlaCalculator { get; }
        public string RecalculatePriorityFromText()
        {
            // Keyword heuristics will churn with support playbooks; SLA math will not.
            var blob = (Ticket.Subject + " " + Ticket.Body).ToLowerInvariant();
            if (blob.Contains("down") || blob.Contains("outage") || blob.Contains("cannot login"))
               return "P1";
            else if (blob.Contains("urgent") || blob.Contains("asap") || blob.Contains("blocked"))
                return"P2";
            else
               return "P3";
        }
    }
}
