using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7.Service;

namespace Task7.StudentInformationSystem
{
    internal class StudentInfoSystem
    {
        StudentService studentService;
        CourseService courseService;
        EnrollmentService enrollmentService;
        TeacherService teacherService;
        PaymentService paymentService;

        public StudentInfoSystem()
        {
            studentService = new StudentService();
            courseService = new CourseService();
            enrollmentService = new EnrollmentService();
            teacherService = new TeacherService();
            paymentService = new PaymentService();
        }

        public void MainMenu()
        {
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine("--------------");
                Console.WriteLine($"1: Student\n2: Course\n3: Enrollment\n4: Teacher\n5: Payment\n6: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        studentService.HandleStudentMenu();
                        break;

                    case 2:
                        courseService.HandleCourseMenu();
                        break;

                    case 3:
                        enrollmentService.HandleEnrollmentMenu();
                        break;

                    case 4:
                        teacherService.HandleTeacherMenu();
                        break;

                    case 5:
                        paymentService.HandlePaymentMenu();
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again...");
                        break;
                }
            } while (choice != 6);
        }
    }
}
