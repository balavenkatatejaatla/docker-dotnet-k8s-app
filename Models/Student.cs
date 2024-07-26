// File: Models/Student.cs
namespace StudentApp.Models
{
    public class Student
    {
        public int student_id { get; set; } // Should match the database column name
        public string student_name { get; set; }
        public int student_age { get; set; }
        public string student_addr { get; set; }
        public double student_percent { get; set; }
        public string student_qual { get; set; }
        public int student_year_passed { get; set; }
    }
}
