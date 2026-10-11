using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.SupportTicket
{
    public class Ticket
    {
        public string Id { get; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string Priority { get; private set; } = "P3";
        public DateTimeOffset OpenedAt { get; }

        PriorityCalculate priorityCalculate;




        public Ticket(string id, string subject, string body, DateTimeOffset openedAt, PriorityCalculate priorityCalculate)
        {
            Id = id;
            Subject = subject;
            Body = body;
            this.priorityCalculate = priorityCalculate;
            OpenedAt = openedAt;
            Priority = priorityCalculate.RecalculatePriorityFromText(Subject, Body);
        }

        public void AppendCustomerMessage(string text)
        {
            Body += "\n---\n" + text;
            Priority = priorityCalculate.RecalculatePriorityFromText(Subject, Body);
        }







       

        

        


    }
}
