using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook_CSharp
{
    public class GeneralGradeBook
    {
        public List<Exam> examList { get; set; }

        public GeneralGradeBook()
        {
            examList = new List<Exam>();
        }

        public Exam this[int x]
        {
            get
            {
                if (x < examList.Count)
                {
                    return examList[x];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                examList[x] = value;
            }
        }

        public Exam Exam
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
