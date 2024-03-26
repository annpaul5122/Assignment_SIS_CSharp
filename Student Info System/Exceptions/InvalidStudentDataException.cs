using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;

namespace Student_Info_System.Exceptions
{
    internal class InvalidStudentDataException:Exception
    {
        public InvalidStudentDataException(string message):base(message)
        {
            
        }
        public static void InvalidStudentData(Student student)
        {
            if(student.DateofBirth > DateTime.Now)
            {
                throw new InvalidStudentDataException("Invalid date of birth!!!");
            }
            else if(!student.Email.Contains('@'))
            {
                throw new InvalidStudentDataException("Invalid email address!!!");
            }
        }
    }
}
