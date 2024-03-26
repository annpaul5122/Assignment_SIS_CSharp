using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Info_System.Models
{
    internal class Enrollment
    {
      
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public Enrollment() { }

        public Enrollment(int enrollmentId, int studentId, int courseId, DateTime enrollmentDate)
        {
            EnrollmentId = enrollmentId;
            StudentId = studentId;
            CourseId = courseId;
            EnrollmentDate = enrollmentDate;
        }

        public override string ToString()
        {
            return $"{EnrollmentId} {StudentId} {CourseId} {EnrollmentDate}";
        }
    }
}
