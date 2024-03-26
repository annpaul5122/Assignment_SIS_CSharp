using Student_Info_System.Repositories;
using Student_Info_System.Models;
using System.Xml.Serialization;
using System.Transactions;
using Student_Info_System.Exceptions;

namespace Student_Info_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentRepository studentRepository = new StudentRepository();
            CourseRepository courseRepository = new CourseRepository();
            EnrollmentRepository enrollmentRepository = new EnrollmentRepository();
            TeacherRepository teacherRepository = new TeacherRepository();
            PaymentRepository paymentRepository = new PaymentRepository();
            int choice = 0, choice1 = 0, choice2 = 0, choice3 = 0, choice4 = 0, choice5 = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine("--------------");
                Console.WriteLine($"1: Student\n2: Course\n3: Enrollment\n4: Teacher\n5: Payment\n6:Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Student student = new Student();

                        do
                        {
                            Console.WriteLine("Student Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine($"1: Insert Student Records\n2: Update student Records\n3: Enrole Student in Course\n4: Make Payment\n5: Display Student Records\n6: Get enrolled courses\n7: Get payment history\n8: Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice1 = int.Parse(Console.ReadLine());
                            switch (choice1)
                            {

                                case 1:
                                    try
                                    {
                                        Console.WriteLine("Enter Student id: ");
                                        int id = int.Parse(Console.ReadLine());
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
                                        student = new Student(id, fname, lname, DateTime.Parse(dob), email, phno);
                                        InvalidStudentDataException.InvalidStudentData(student);
                                        studentRepository.InsertRecords(student);
                                        Console.WriteLine("Record inserted successfully");
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message);}
                                    break;

                                case 2:
                                    try
                                    {
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
                                        Student student1 = new Student(u_id, u_fname, u_lname, DateTime.Parse(u_dob), u_email, u_phno);
                                        InvalidStudentDataException.InvalidStudentData(student1);
                                        studentRepository.UpdateStudentInfo(student1);
                                        Console.WriteLine("Record updated successfully");
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message);}
                                    break;

                                case 3:
                                    try
                                    {
                                        Console.WriteLine("Enter Course id: ");
                                        int c_id = int.Parse(Console.ReadLine());
                                        Course courses = new Course();
                                        courses.CourseId = c_id;
                                        CourseNotFoundException.CourseNotFound(courses);
                                        Console.WriteLine("Enter student id: ");
                                        int s_id = int.Parse(Console.ReadLine());
                                        StudentNotFoundException.StudentNotFound(s_id);
                                        Console.WriteLine("Enter enrollment id: ");
                                        DuplicateEnrollmentException.DuplicateEnrollment(s_id);
                                        int e_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter enrollment date: ");
                                        string e_date = Console.ReadLine();
                                        studentRepository.EnrollInCourse(courses, s_id, e_id, DateTime.Parse(e_date));
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 4:
                                    try
                                    {
                                        Console.WriteLine("Enter Payment Id: ");
                                        int p_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter student id: ");
                                        int studentid = int.Parse(Console.ReadLine());
                                        StudentNotFoundException.StudentNotFound(studentid);
                                        Console.WriteLine("Enter amount");
                                        decimal amount = decimal.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter payment date: ");
                                        string p_date = Console.ReadLine();
                                        studentRepository.MakePayment(p_id, studentid, amount, DateTime.Parse(p_date));
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 5:
                                    Console.WriteLine("List of students: ");
                                    studentRepository.DisplayStudentInfo();
                                    break;

                                case 6:
                                    Console.WriteLine("Enter student id: ");
                                    int s_id1 = int.Parse(Console.ReadLine());
                                    studentRepository.GetEnrolledCourses(s_id1);
                                    break;

                                case 7:
                                    Console.WriteLine("Enter student id: ");
                                    int s_id2 = int.Parse(Console.ReadLine());
                                    studentRepository.GetPaymentHistory(s_id2);
                                    break;

                                case 8:
                                    Console.WriteLine("Exiting...");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice1 != 8);
                        break;

                    case 2:
                        Console.Clear();
                        Course course = new Course();
                        do
                        {
                            Console.WriteLine("Course Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine($"1: Insert Course Records\n2: Update Course Records\n3: Get enrollments\n4: Get teacher\n5: Display course Records\n6: Assign Teacher\n7: Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice2 = int.Parse(Console.ReadLine());
                            switch (choice2)
                            {
                                case 1:
                                    try
                                    {
                                        Console.WriteLine("Enter course id: ");
                                        int c_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter course name: ");
                                        string c_name = Console.ReadLine();
                                        Console.WriteLine("Enter course code: ");
                                        string c_code = Console.ReadLine();
                                        Console.WriteLine("Enter instructor name: ");
                                        string instructor = Console.ReadLine();
                                        course = new Course(c_id, c_name, c_code, instructor);
                                        InvalidCourseDataexception.InvalidCourseData(course);
                                        courseRepository.InsertDetails(course);
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Enter course id: ");
                                        int u_cid = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter course name: ");
                                        string u_cname = Console.ReadLine();
                                        Console.WriteLine("Enter course code: ");
                                        string u_ccode = Console.ReadLine();
                                        Console.WriteLine("Enter instructor name: ");
                                        string u_instructor = Console.ReadLine();
                                        Course course1 = new Course(u_cid, u_cname, u_ccode, u_instructor);
                                        InvalidCourseDataexception.InvalidCourseData(course1);
                                        courseRepository.UpdateCourseInfo(course1);
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 3:
                                    Console.WriteLine("Enter course id: ");
                                    int course_id = int.Parse(Console.ReadLine());
                                    courseRepository.GetEnrollments(course_id);
                                    break;

                                case 4:
                                    Console.WriteLine("Enter course name: ");
                                    string course_name = Console.ReadLine();
                                    courseRepository.GetTeacher(course_name);
                                    break;

                                case 5:
                                    Console.WriteLine("Course List: ");
                                    courseRepository.DisplayRecords();
                                    break;

                                case 6:
                                    try
                                    {
                                        Console.WriteLine("Enter teacher id: ");
                                        int t_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter first name: ");
                                        string t_fname = Console.ReadLine();
                                        Console.WriteLine("Enter last name: ");
                                        string t_lname = Console.ReadLine();
                                        Console.WriteLine("Enter email: ");
                                        string t_email = Console.ReadLine();
                                        Teacher teachers = new Teacher(t_id,t_fname,t_lname,t_email);
                                        TeacherNotFoundException.TeacherNotFound(teachers);
                                        Console.WriteLine("Enter course id: ");
                                        int cid = int.Parse(Console.ReadLine());
                                        Course course2 = new Course();
                                        course2.CourseId = cid;
                                        CourseNotFoundException.CourseNotFound(course2);
                                        courseRepository.AssignTeacher(teachers, course);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 7:
                                    Console.WriteLine("Exiting..");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice2 != 7);
                        break;

                    case 3:
                        Console.Clear();
                        Enrollment enrollment = new Enrollment();
                        do
                        {
                            Console.WriteLine("Enrollment Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine($"1: Insert Enrollment Records\n2: Get Student\n3: Get Course\n4: Display Enrollment Records\n5: Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice3 = int.Parse(Console.ReadLine());
                            switch (choice3)
                            {
                                case 1:
                                    try
                                    {
                                        Console.WriteLine("Enter enrollment id: ");
                                        int e_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter student id: ");
                                        int s_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter course id: ");
                                        int c_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter enrollment date: ");
                                        string e_date = Console.ReadLine();
                                        enrollment = new Enrollment(e_id, s_id, c_id, DateTime.Parse(e_date));
                                        InvalidEnrollmentDataException.InvalidEnrollmentData(enrollment);
                                        enrollmentRepository.InsertDetails(enrollment);
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 2:
                                    Console.WriteLine("Enter student id: ");
                                    int studentId = int.Parse(Console.ReadLine());
                                    enrollmentRepository.GetStudent(studentId);
                                    break;

                                case 3:
                                    Console.WriteLine("Enter course id: ");
                                    int courseId = int.Parse(Console.ReadLine());
                                    enrollmentRepository.GetCourse(courseId);
                                    break;

                                case 4:
                                    Console.WriteLine("Enrollment list: ");
                                    enrollmentRepository.DisplayDetails();
                                    break;

                                case 5:
                                    Console.WriteLine("Exiting..");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;

                            }
                        } while (choice3 != 5);
                        break;

                    case 4:
                        Console.Clear();
                        Teacher teacher = new Teacher();
                        do
                        {
                            Console.WriteLine("Teacher Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine($"1: Insert Enrollment Records\n2: Update teacher details\n3: Get Assigned Course\n4: Display Teacher info\n5: Exit\n");
                            Console.WriteLine("Enter your choice: ");

                            choice4 = int.Parse(Console.ReadLine());
                            switch (choice4)
                            {
                                case 1:
                                    try
                                    {
                                        Console.WriteLine("Enter teacher id: ");
                                        int t_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter first name: ");
                                        string fname = Console.ReadLine();
                                        Console.WriteLine("Enter last name: ");
                                        string lname = Console.ReadLine();
                                        Console.WriteLine("Enter email: ");
                                        string email = Console.ReadLine();
                                        teacher = new Teacher(t_id, fname, lname, email);
                                        InvalidTeacherDataException.InvalidTeacherData(teacher);
                                        teacherRepository.InsertDetails(teacher);
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 2:
                                    try
                                    {
                                        Console.WriteLine("Enter teacher id: ");
                                        int u_tid = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter first name: ");
                                        string u_fname = Console.ReadLine();
                                        Console.WriteLine("Enter last name: ");
                                        string u_lname = Console.ReadLine();
                                        Console.WriteLine("Enter email: ");
                                        string u_email = Console.ReadLine();
                                        Teacher teacher1 = new Teacher(u_tid, u_fname, u_lname, u_email);
                                        InvalidTeacherDataException.InvalidTeacherData(teacher1);
                                        teacherRepository.UpdateTeacherInfo(teacher1);
                                    }
                                    catch(Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 3:
                                    Console.WriteLine("Enter teacher name: ");
                                    string teacherName = Console.ReadLine();
                                    teacherRepository.GetAssignedCourses(teacherName);
                                    break;

                                case 4:
                                    Console.WriteLine("Teacher details: ");
                                    teacherRepository.displayDetails();
                                    break;

                                case 5:
                                    Console.WriteLine("Exiting...");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice4 != 5);
                        break;

                    case 5:
                        Console.Clear();
                        Payment payment = new Payment();
                        do
                        {
                            Console.WriteLine("Payment Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine($"1: Insert Payment Records\n2: Get student\n3: Get payment amount\n4. Get payment date\n5: Display Payment info\n6: Exit\n");
                            Console.WriteLine("Enter your choice: ");

                            choice5 = int.Parse(Console.ReadLine());
                            switch (choice5)
                            {
                                case 1:
                                    try
                                    {
                                        Console.WriteLine("Enter payment id: ");
                                        int p_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter student id: ");
                                        int s_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter amount: ");
                                        decimal amount = decimal.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter payment date: ");
                                        string p_date = Console.ReadLine();
                                        payment = new Payment(p_id, s_id, amount, DateTime.Parse(p_date));
                                        PaymentValidationException.PaymentError(payment);
                                        paymentRepository.InsertDetails(payment);
                                    }
                                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                                    break;

                                case 2:
                                    Console.WriteLine("Enter student id: ");
                                    int student_id = int.Parse(Console.ReadLine());
                                    paymentRepository.GetStudent(student_id);
                                    break;

                                case 3:
                                    Console.WriteLine("Enter payment id: ");
                                    int payment_id = int.Parse(Console.ReadLine());
                                    paymentRepository.GetPaymentAmount(payment_id);
                                    break;

                                case 4:
                                    Console.WriteLine("Enter payment id: ");
                                    int paymentId = int.Parse(Console.ReadLine());
                                    paymentRepository.GetPaymentdate(paymentId);
                                    break;

                                case 5:
                                    Console.WriteLine("Payment info: ");
                                    paymentRepository.displayDetails();
                                    break;

                                case 6:
                                    Console.WriteLine("Exiting...");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice5 != 5);
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 6);

        }
    }
}
