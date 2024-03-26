using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;

namespace Student_Info_System.Repositories
{
    internal class EnrollmentRepository
    {
        public static List<Enrollment> enrollments = new List<Enrollment>();
        public void InsertDetails(Enrollment enrollment)
        {
            enrollments.Add(enrollment);
        }

        public void DisplayDetails()
        {
            foreach (Enrollment item in enrollments)
            {
                Console.WriteLine(item);
            }
        }

        public void GetStudent(int studentId)
        {
        
            foreach (Student item in StudentRepository.stud)
            {
                if(item.StudentId==studentId)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void GetCourse(int courseId)
        {
           
            foreach (Course item in CourseRepository.courses)
            {
                if(item.CourseId==courseId)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
