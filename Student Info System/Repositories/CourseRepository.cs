using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;

namespace Student_Info_System.Repositories
{
    internal class CourseRepository
    {
        public static List<Course> courses = new List<Course>();
       
        public void InsertDetails(Course course)
        {
            courses.Add(course);
        }

        public void AssignTeacher(Teacher teacher,Course course)
        {
            foreach(Course item in courses)
            {
                if(item.CourseName == course.CourseName && course.InstructorName==null )
                {
                    item.InstructorName= string.Concat(teacher.FirstName, teacher.LastName);
                }
            }
        }

        public void GetEnrollments(int c_id)
        {
           
            foreach (Enrollment item in EnrollmentRepository.enrollments)
            {
                if(item.CourseId == c_id)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void GetTeacher(string course_name)
        {
            foreach(Course item in courses)
            {
                if(item.CourseName == course_name)
                {
                    Console.WriteLine($"Teacher: {item.InstructorName}");
                }
            }
        }

        public void UpdateCourseInfo(Course course)
        {
            foreach(Course item in courses)
            {
                if(item.CourseId==course.CourseId)
                {
                    item.CourseCode= course.CourseCode;
                    item.CourseName= course.CourseName;
                    item.InstructorName= course.InstructorName;
                }
            }
        }

        public void DisplayRecords()
        {
            foreach(Course item in courses)
            {
                Console.WriteLine(item);
            }
        }

    }
}
