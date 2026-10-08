using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab
{
    public class PagerService
    {
        //private readonly List<string> _pagerLog = new();
        public List<string> PagerLog { get; } = new();

        public List<string> DrainPagerLog()
        {
            var copy = PagerLog.ToList();
            PagerLog.Clear();
            return copy;
        }

        public void AddPagerLog(int bed)
        {
            PagerLog.Add($"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}");
        }


    }
}
