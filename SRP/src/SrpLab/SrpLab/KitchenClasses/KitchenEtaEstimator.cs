using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.KitchenClasses
{
    public class KitchenEtaEstimator
    {
        private readonly KitchenTicket kitchenTicket;
        private readonly AllergensDetector allergensDetector;

        public KitchenEtaEstimator(KitchenTicket kitchenTicket, AllergensDetector allergensDetector)
        {
            this.kitchenTicket = kitchenTicket;
            this.allergensDetector = allergensDetector;
        }

        public int EstimatedReadyMinutes(int openStations)
        {
            // Kitchen ops model ≠ printing.
            if (openStations <= 0) openStations = 1;
            var sequential =kitchenTicket.Items.Sum(i => i.PrepMinutes);
            var parallel = (int)Math.Ceiling(sequential / (double)openStations);
            if (allergensDetector.DetectAllergens().Count > 0) parallel += 3; // allergy protocol delay mixed in
            var longest = kitchenTicket.Items.Count == 0 ? 0 : kitchenTicket.Items.Max(i => i.PrepMinutes);
            return Math.Max(parallel, longest);
        }
    }
}
