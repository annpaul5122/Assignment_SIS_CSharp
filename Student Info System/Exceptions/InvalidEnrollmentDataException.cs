using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;

namespace Student_Info_System.Exceptions
{
    internal class InvalidEnrollmentDataException:Exception
    {
        public InvalidEnrollmentDataException(string message):base(message)
        {
            
        }

        public static void InvalidEnrollmentData(Enrollment enrollment)
        {
            if(enrollment.StudentId==null)
            {
                throw new InvalidEnrollmentDataException("Student id missing");
            }
            else if(enrollment.CourseId==null)
            {
                throw new InvalidEnrollmentDataException("Course id missing");
            }
        }
    }
}
