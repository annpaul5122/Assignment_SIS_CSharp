using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;
using Student_Info_System.Repositories;

namespace Student_Info_System.Exceptions
{
    internal class TeacherNotFoundException : Exception
    {
        public TeacherNotFoundException(string message):base(message)
        {
            
        }

        public static void TeacherNotFound(Teacher teacher)
        {
            if (!TeacherRepository.teachers.Contains(teacher))
            {
                throw new TeacherNotFoundException("Teacher not found!!");
            }
        }
    }
}
