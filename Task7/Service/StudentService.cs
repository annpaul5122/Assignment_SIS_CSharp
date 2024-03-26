using Student_Info_System.Repositories;
using Student_Info_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Exceptions;

namespace Task7.Service
{
    internal class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public void AddRecords(Student student)
        {
            try
            {
                InvalidStudentDataException.InvalidStudentData(student);
                _studentRepository.InsertRecords(student);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); } 
        }

        public void UpdateRecords(Student student)
        {

            try
            {
                InvalidStudentDataException.InvalidStudentData(student);
                _studentRepository.UpdateStudentInfo(student);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
           
        }

       public void EnrollStudentInCourse(Course course,int studentId)
        {
            try
            {
                CourseNotFoundException.CourseNotFound(course);
                StudentNotFoundException.StudentNotFound(studentId);
                Enrollment enrollment= new Enrollment();
                enrollment.CourseId = course.CourseId;
                enrollment.StudentId = studentId;
                DuplicateEnrollmentException.DuplicateEnrollment(enrollment);
                _studentRepository.EnrollInCourse(course, studentId);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MakePaymentByStudentId(int studentId,int amount)
        {
            try
            {
                Payment payment = new Payment();
                payment.Amount = amount;
                StudentNotFoundException.StudentNotFound(studentId);
                PaymentValidationException.PaymentError(payment);
                _studentRepository.MakePayment(studentId, amount);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetEnrolledCoursesbyStudent(int studentId)
        {
            try
            {
                StudentNotFoundException.StudentNotFound(studentId);
                foreach(Enrollment item in _studentRepository.GetEnrolledCourses(studentId))
                {
                    Console.WriteLine(item);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetPaymentByStudent(int studentId)
        {
            try
            {
                StudentNotFoundException.StudentNotFound(studentId);
                foreach(Payment item in _studentRepository.GetPaymentHistory(studentId))
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayStudentRecords()
        {
            foreach(Student item in _studentRepository.DisplayStudentInfo())
            {
                Console.WriteLine(item);
            }
        }

        public void HandleStudentMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Student Management");
                Console.WriteLine("---------------------");
                Console.WriteLine($"1: Insert Student Records\n2: Update student Records\n3: Enrole Student in Course\n4: Make Payment\n5: Display Student Records\n6: Get enrolled courses\n7: Get payment history\n8: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Student student = new Student();
                switch (choice)
                {
                    case 1:
                            Console.WriteLine("Enter first name: ");
                            string fname = Console.ReadLine();
                            Console.WriteLine("Enter last name: ");
                            string lname = Console.ReadLine();
                            Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
                            string dob = Console.ReadLine();
                            Console.WriteLine("Enter email: ");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter phone number: ");
                            string phno = Console.ReadLine();
                            student = new Student() { FirstName = fname, LastName=lname, DateofBirth=DateTime.Parse(dob),Email=email,PhoneNumber=phno};
                            AddRecords(student);
                            Console.WriteLine("Record inserted successfully");
                            break;

                    case 2:
                            Console.WriteLine("Enter Student id to be updated: ");
                            int u_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter first name: ");
                            string u_fname = Console.ReadLine();
                            Console.WriteLine("Enter last name: ");
                            string u_lname = Console.ReadLine();
                            Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
                            string u_dob = Console.ReadLine();
                            Console.WriteLine("Enter email: ");
                            string u_email = Console.ReadLine();
                            Console.WriteLine("Enter phone number: ");
                            string u_phno = Console.ReadLine();
                            Student student1 = new Student(u_id,u_fname, u_lname, DateTime.Parse(u_dob), u_email, u_phno);
                            UpdateRecords(student1);
                            Console.WriteLine("Record updated successfully");
                            break;

                    case 3:
                            Console.WriteLine("Enter Course id: ");
                            int c_id = int.Parse(Console.ReadLine());
                            Course courses = new Course();
                            courses.CourseId = c_id;
                            Console.WriteLine("Enter student id: ");
                            int s_id = int.Parse(Console.ReadLine());
                            EnrollStudentInCourse(courses, s_id);
                            break;

                    case 4:
                            Console.WriteLine("Enter student id: ");
                            int studentid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter amount");
                            int amount = int.Parse(Console.ReadLine());
                            MakePaymentByStudentId(studentid, amount);
                            break;

                    case 5:
                           Console.WriteLine("List of students: ");
                           DisplayStudentRecords();
                           break;

                    case 6:
                        Console.WriteLine("Enter student id: ");
                        int s_id1 = int.Parse(Console.ReadLine());
                        GetEnrolledCoursesbyStudent(s_id1);
                        break;

                    case 7:
                        Console.WriteLine("Enter student id: ");
                        int s_id2 = int.Parse(Console.ReadLine());
                        GetPaymentByStudent(s_id2);
                        break;

                    case 8:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 8);
        }
    }
}
