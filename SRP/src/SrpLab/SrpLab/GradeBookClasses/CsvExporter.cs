using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.GradeBookClasses
{
    public class CsvExporter
    {
        GradeBook gradeBook;

        public CsvExporter(GradeBook gradeBook)
        {
            this.gradeBook = gradeBook;
        }

        public string ExportCsv(decimal avg,string letter,bool isHonor)
        {
            var rows = new List<string> { "studentId,average,letter,honor" };
            foreach (var id in gradeBook.Scores.Keys.OrderBy(x => x))
                rows.Add($"{id},{avg},{letter},{(isHonor ? 1 : 0)}");
            return string.Join('\n', rows);
        }
    }
}
