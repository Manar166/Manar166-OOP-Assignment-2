using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab
{
    public class HandoffNoteBuilder
    {
        public string BuildHandoffNote(int bed,WardBoard wardBoard)
        {
            if (!wardBoard.BedPatient.TryGetValue(bed, out var patient))
                return $"Bed {bed}: empty";

            var acuity = wardBoard.VitalsScore[bed];
            var tone = acuity >= 8 ? "ESCALATE" : acuity >= 4 ? "WATCH" : "STABLE";
            // Presentation / narrative format will change without clinical rules changing.
            return $"[HANDOFF {DateTime.UtcNow:yyyy-MM-dd}] Bed {bed} · {patient} · acuity={acuity} · {tone}";
        }
    }
}
