using System;
using System.Collections.Generic;
using System.Text;

namespace SrpLab.GradeBookClasses
{
    public class TranscriptGenerator
    {
        public string TranscriptPlain(string studentId, string fullName ,decimal avg,string letter ,bool honor)
        {
            // Registrar document format ≠ grading policy.
            return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {avg}\nLetter: {letter}\nHonor: {honor}\n";
        }
    }
}
