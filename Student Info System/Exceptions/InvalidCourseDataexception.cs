using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;

namespace Student_Info_System.Exceptions
{
    internal class InvalidCourseDataexception:Exception
    {
        public InvalidCourseDataexception(string message):base(message)
        {
            
        }

        public static void InvalidCourseData(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.CourseCode))
            {
                throw new InvalidCourseDataexception("Invalid course code!!");
            }
            else if(string.IsNullOrWhiteSpace(course.InstructorName)) 
            {
                throw new InvalidCourseDataexception("Invalid instructor name!!");
            }
        }
    }
}
