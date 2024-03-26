using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;
using Student_Info_System.Repositories;

namespace Student_Info_System.Exceptions
{
    internal class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message): base(message)
        {
            
        }

        public static void StudentNotFound(int studentId)
        {
            bool studentExists = false;
            foreach(Student item in StudentRepository.stud)
            {
                if(item.StudentId == studentId)
                {
                    studentExists = true;
                    break;
                }
            }
            if(!studentExists)
            {
                throw new StudentNotFoundException("Student not found!!!");
            }
        }
    }
}
