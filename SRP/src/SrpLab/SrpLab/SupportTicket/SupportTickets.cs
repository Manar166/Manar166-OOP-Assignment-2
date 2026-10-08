using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SupportTicket
{
    public class SupportTickets
    {
        public string Id { get; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string Priority { get; private set; } = "P3";

        SlaCalculator SlaCalculator;




        public SupportTickets(string id, string subject, string body, SlaCalculator SlaCalculator)
        {
            Id = id;
            Subject = subject;
            Body = body;
            this.SlaCalculator = SlaCalculator;

            RecalculatePriority();
        }

        public void AppendCustomerMessage(string text)
        {
            Body += "\n---\n" + text;
            RecalculatePriority();
        }

       





        public string DraftPublicReply(string agentName)
        {
            // Tone/templates owned by CX — not by SLA engineering.
            var apology = Priority == "P1" ? "We are treating this as a critical incident." : "Thanks for reaching out.";
            return $"Hi,\n{apology}\nTicket {Id} is with {agentName}. Next update before {SlaCalculator.SlaDeadline():u}.\n";
        }

        public string InternalEscalationBlurb()
        {
            return $"ESCALATE {Id} priority={Priority} breachAt={SlaCalculator.SlaDeadline():u} keywords-scanned=yes";
        }

        public void UpDatePriority()
        {
            var calculator = new PriorityCalculate(this);
            Priority = calculator.RecalculatePriorityFromText();
        }


    }
}
