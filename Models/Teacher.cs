using System;

namespace C__Cumulative_Part_1.Models
{
    public class Teacher
    {
        // Unique ID for the teacher
        public int TeacherId { get; set; }

        // First name of the teacher
        public string TeacherFirstName { get; set; }

        // Last name of the teacher
        public string TeacherLastName { get; set; }

        // Internal employee number
        public string EmployeeNumber { get; set; }

        // Date the teacher was hired
        public DateTime HireDate { get; set; }

        // Teacher's salary
        public double Salary { get; set; }
    }
}



