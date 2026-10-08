using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab
{
    internal class CensusCsv
    {
        public string ExportCensusCsv(WardBoard wardBoard)
        {
            // Persistence/export shape mixed into the same type as acuity + paging.
            var lines = new List<string> { "bed,patient,acuity" };
            foreach (var bed in wardBoard.BedPatient.Keys.OrderBy(x => x))
                lines.Add($"{bed},{wardBoard.BedPatient[bed]},{wardBoard.VitalsScore[bed]}");
            return string.Join('\n', lines);
        }

    }
}
