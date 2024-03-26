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
        public int? Credits { get; set; }
        public int? InstructorId { get; set; }

        public Course()
        {

        }

        public Course(int courseId, string courseName, int credits, int instructorId)
        {
            CourseId = courseId;
            CourseName = courseName;
            Credits = credits;
            InstructorId = instructorId;
        }

        public override string ToString()
        {
            return $"{CourseId} {CourseName} {Credits} {InstructorId}";
        }
    }
}
