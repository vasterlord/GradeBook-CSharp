using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook_CSharp
{
    interface ILecturer
    {
        string Position { get; set; }
        string LecturerSurname { get; set; }
        void GetLecturerSurname();
    }
}
