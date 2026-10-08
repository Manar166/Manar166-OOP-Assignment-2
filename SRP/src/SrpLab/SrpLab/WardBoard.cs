using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab
{
    public class WardBoard
    {
        public Dictionary<int, int> VitalsScore { get; } = new();

        public Dictionary<int, string> BedPatient { get; } = new();
        public PagerService PagerService { get; }

        public AcuityCalculator AcuityCalculator { get; }


        public WardBoard(PagerService pagerService, AcuityCalculator acuityCalculator)
        {
            PagerService = pagerService;
            AcuityCalculator = acuityCalculator;
        }

            //private readonly List<string> _pagerLog = new();
            

        public void AssignBed(int bed, string patientId, int heartRate, int spo2)
            {
                if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
                if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");

                BedPatient[bed] = patientId.Trim().ToUpperInvariant();
                VitalsScore[bed] = AcuityCalculator.ScoreAcuity(heartRate, spo2);

                if (VitalsScore[bed] >= 8)
                PagerService.AddPagerLog(bed);
            }

        
            

          
         

        

        


    }
}
