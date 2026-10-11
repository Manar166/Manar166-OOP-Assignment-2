using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.KitchenClasses
{
    public class ThermalTicketRenderer
    {
        private readonly KitchenTicket kitchenTicket;
        private readonly AllergensDetector allergensDetector;
        private readonly KitchenEtaEstimator kitchenEtaEstimator;

        public ThermalTicketRenderer(KitchenTicket kitchenTicket, 
            AllergensDetector allergensDetector,
            KitchenEtaEstimator kitchenEtaEstimator)
        {
            this.kitchenTicket = kitchenTicket;
            this.allergensDetector = allergensDetector;
            this.kitchenEtaEstimator = kitchenEtaEstimator;
        }
        public string RenderThermalTicket(int orderNumber)
        {
            // Hardware/formatting concerns — width, separators — change with printer vendor.
            var width = 32;
            var line = new string('=', width);
            var body = string.Join('\n', kitchenTicket.Items.Select(i => $"* {i.Item.ToUpperInvariant()} ({i.PrepMinutes}m)"));
            var allergens = allergensDetector.DetectAllergens();
            var allergyLine = allergens.Count == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
            return $"{line}\nORDER #{orderNumber}\nETA {kitchenEtaEstimator.EstimatedReadyMinutes(2)} MIN\n{body}\n{allergyLine}\n{line}\n";
        }
    }
}
