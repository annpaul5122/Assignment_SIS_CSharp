using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;

namespace Student_Info_System.Exceptions
{
    internal class InvalidTeacherDataException:Exception
    {
        public InvalidTeacherDataException(string message):base(message)
        {
            
        }
        public static void InvalidTeacherData(Teacher teacher)
        {
            if(teacher.FirstName==null || teacher.LastName==null)
            {
                throw new InvalidTeacherDataException("Teacher name is null!!!");
            }
            else if(teacher.Email==null)
            {
                throw new InvalidTeacherDataException("Email is null!!!");
            }
        }
    }
}
