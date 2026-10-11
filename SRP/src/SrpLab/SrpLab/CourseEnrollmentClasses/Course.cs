namespace SrpLab;

/// <summary>
/// Course enrollment: capacity, waitlist math, welcome-packet markdown, and invoice lines.
/// </summary>
public sealed class Course
{

    public int Capacity { get; }
    public decimal Tuition { get; }
    public string CourseCode { get; }

    public Course(string courseCode, int capacity, decimal tuition)
    {
        CourseCode = courseCode;
        Capacity = capacity;
        Tuition = tuition;
    }

   
   

    

 
}
