using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook_CSharp
{
    public class Exam : IStudent, ILecturer
    {
        public int id { get; set; }
        public string Group { get; set; }

        public string StudentSurname { get; set; }

        public string Position { get; set; }

        public string LecturerSurname { get; set; } 

        public string Subject { get; set; } 

        public int CountHours { get; set; } 

        public DateTime Date { get; set; } 

        public int Mark { get; set; } 

        public Exam()
        {
            Group = "Unknown";
            StudentSurname = "Unknown";
            LecturerSurname = "Unknown";
            Position = "Unknown";
            Subject = "Unknown";
            CountHours = 10;
            Date = DateTime.Today.Date;
            Mark = 2;
        }

        public Exam(string group, string studentSurname, string position, string lecturerSurname, string subject, int countHours, DateTime date, int mark)
        {
            Group = group;
            StudentSurname = studentSurname;
            LecturerSurname = lecturerSurname;
            Position = position; 
            Subject = subject;
            CountHours = countHours;
            Date = date;
            Mark = mark;
        }
        public void GetStudentSurname()
        {
            StudentSurname = string.Concat("Student" + " " + StudentSurname);
        }

        public void GetLecturerSurname()
        {
            LecturerSurname = string.Concat("Lectuturer" + " " + LecturerSurname);
        }

       
    }
}
