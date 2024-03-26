using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;
using Student_Info_System.Repositories;
using Student_Info_System.Exceptions;

namespace Task7.Service
{
    internal class EnrollmentService
    {
        private readonly EnrollmentRepository _enrollmentRepository;

        public EnrollmentService()
        {
            _enrollmentRepository = new EnrollmentRepository();
        }

        public void GetStudentByEnrollment(int enrollmentId)
        {
            Console.WriteLine($"Student: {_enrollmentRepository.GetStudent(enrollmentId)}");
        }

        public void GetCourseByEnrollments(int enrollmentId)
        {
           Console.WriteLine($"Course: {_enrollmentRepository.GetCourse(enrollmentId)}");
        }

        public void HandleEnrollmentMenu()
        {
            Enrollment enrollment = new Enrollment();
            int choice = 0;
            do
            {
                Console.WriteLine("Enrollment Management");
                Console.WriteLine("---------------------");
                Console.WriteLine($"1: Get Student\n2: Get Course\n3: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter enrollment id: ");
                        int enrollmentId = int.Parse(Console.ReadLine());
                        GetStudentByEnrollment(enrollmentId);
                        break;

                    case 2:
                        Console.WriteLine("Enter enrollment id: ");
                        int enrollment_Id = int.Parse(Console.ReadLine());
                        GetCourseByEnrollments(enrollment_Id);
                        break;

                    case 3:
                        Console.WriteLine("Exiting..");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 3);
        }
    }
}
