using Student_Info_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;
using Student_Info_System.Exceptions;

namespace Task7.Service
{
    internal class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService()
        {
            _courseRepository = new CourseRepository();
        }

        public void AssignTeacherToCourse(Teacher teacher,Course course)
        {
            try
            {
                TeacherNotFoundException.TeacherNotFound(teacher);
                CourseNotFoundException.CourseNotFound(course);
                _courseRepository.AssignTeacher(teacher, course);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetEnrollentByCourse(int course_id)
        {
            try
            {
                Course course = new Course();
                course.CourseId = course_id;
                CourseNotFoundException.CourseNotFound(course);
                foreach(Enrollment item in _courseRepository.GetEnrollments(course_id))
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetTeacherByCourse(string courseName)
        {
            try
            {
                Course course = new Course();
                course.CourseName = courseName;
                InvalidCourseDataexception.InvalidCourseData(course);
                foreach(string item in _courseRepository.GetTeacher(courseName))
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateCourseDetails(Course course)
        {
            try
            {
                CourseNotFoundException.CourseNotFound(course);
                _courseRepository.UpdateCourseInfo(course);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayCourse()
        {
            foreach(Course item in _courseRepository.DisplayCourseInfo())
            {
                Console.WriteLine(item);
            }
        }

        public void HandleCourseMenu()
        {
            Course course = new Course();
            int choice = 0;
            do
            {
                Console.WriteLine("Course Management");
                Console.WriteLine("---------------------");
                Console.WriteLine($"1: Update Course Records\n2: Get enrollments\n3: Get teacher\n4: Display course Records\n5: Assign Teacher\n6: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                { 
                    case 1:
                            Console.WriteLine("Enter course id: ");
                            int u_cid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter course name: ");
                            string u_cname = Console.ReadLine();
                            Console.WriteLine("Enter course credits: ");
                            int u_credits = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter instructor id: ");
                            int u_instructorId = int.Parse(Console.ReadLine());
                            Course course1 = new Course(u_cid, u_cname, u_credits, u_instructorId);
                            UpdateCourseDetails(course1);
                            break;

                    case 2:
                        Console.WriteLine("Enter course id: ");
                        int course_id = int.Parse(Console.ReadLine());
                        GetEnrollentByCourse(course_id);
                        break;

                    case 3:
                        Console.WriteLine("Enter course name: ");
                        string course_name = Console.ReadLine();
                        GetTeacherByCourse(course_name);
                        break;

                    case 4:
                        Console.WriteLine("Course List: ");
                        DisplayCourse();
                        break;

                    case 5:
                            Console.WriteLine("Enter teacher id: ");
                            int t_id = int.Parse(Console.ReadLine());
                            Teacher teachers = new Teacher() {TeacherId=t_id};
                            Console.WriteLine("Enter course id: ");
                            int cid = int.Parse(Console.ReadLine());
                            Course course2 = new Course();
                            course2.CourseId = cid;
                            AssignTeacherToCourse(teachers, course2);
                            break;

                    case 6:
                        Console.WriteLine("Exiting..");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 6);
        }
    }
}
