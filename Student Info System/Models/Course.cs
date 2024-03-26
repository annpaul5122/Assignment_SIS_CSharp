using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Info_System.Models
{
    internal class Course
    {

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string InstructorName { get; set; }

        public Course()
        {

        }

        public Course(int courseId, string courseName, string courseCode, string instructorName)
        {
            CourseId = courseId;
            CourseName = courseName;
            CourseCode = courseCode;
            InstructorName = instructorName;
        }

        public override string ToString()
        {
            return $"{CourseId} {CourseName} {CourseCode} {InstructorName}";
        }
    }
}
