using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.KitchenClasses
{
    public class ExpoLaneSelector
    {
        private readonly KitchenTicket kitchenTicket;
        private readonly AllergensDetector allergensDetector;
        private readonly KitchenEtaEstimator kitchenEtaEstimator;

        public ExpoLaneSelector(KitchenTicket kitchenTicket, 
            AllergensDetector allergensDetector,
            KitchenEtaEstimator kitchenEtaEstimator)
        {
            this.kitchenTicket = kitchenTicket;
            this.allergensDetector = allergensDetector;
            this.kitchenEtaEstimator = kitchenEtaEstimator;
        }

        public string ExpoLaneHint()
        {
            return allergensDetector.DetectAllergens().Count > 0 ? "LANE-ALLERGY" : kitchenEtaEstimator.EstimatedReadyMinutes(2) > 20 ? "LANE-SLOW" : "LANE-FAST";
        }

    }
}
