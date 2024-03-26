using Student_Info_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;

namespace Student_Info_System.Exceptions
{
    internal class DuplicateEnrollmentException : Exception
    {
        public DuplicateEnrollmentException(string message): base (message)
        {
            
        }

        public static void DuplicateEnrollment(int student_id)
        {
            foreach(Enrollment item in EnrollmentRepository.enrollments)
            {
                if(item.StudentId == student_id)
                  throw new DuplicateEnrollmentException("Student already enrolled. Try again!!!");
            }
        }
    }
}
