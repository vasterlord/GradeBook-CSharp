using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook_CSharp
{
    interface IStudent
    {
       string Group { get; set; }
       string StudentSurname { get; set; }
       void GetStudentSurname();
    }
}
