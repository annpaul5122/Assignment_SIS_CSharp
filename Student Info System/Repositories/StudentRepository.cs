using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;

namespace Student_Info_System.Repositories
{
    internal class StudentRepository
    {
        public static List<Student> stud = new List<Student>();

        public void InsertRecords(Student students)
        {
           stud.Add(students);
        }

        public void EnrollInCourse(Course course,int id,int e_id,DateTime e_date)
        {
            EnrollmentRepository.enrollments.Add(new Enrollment(e_id, id, course.CourseId, e_date));
        }

        public void UpdateStudentInfo(Student students)
        {
            foreach(Student stud in stud) 
            { 
                if(stud.StudentId == students.StudentId)
                {
                    stud.FirstName = students.FirstName;
                    stud.LastName =students.LastName;
                    stud.DateofBirth = students.DateofBirth;
                    stud.Email = students.Email;
                    stud.PhoneNumber = students.PhoneNumber;
                    break;
                }
            }
        }

        public void MakePayment(int p_id,int id,decimal amount,DateTime payment_date)
        {
           
           PaymentRepository.payments.Add(new Payment(p_id, id, amount, payment_date));
        }
        
        public void GetEnrolledCourses(int s_id)
        {
          
            foreach (Enrollment item in EnrollmentRepository.enrollments)
            {
                if(item.StudentId==s_id)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void GetPaymentHistory(int s_id)
        {
            foreach (Payment item in PaymentRepository.payments)
            {
                if(item.StudentId==s_id)
                {
                    Console.WriteLine(item);
                } 
            }
        }
        public void DisplayStudentInfo()
        {
            foreach(Student item in stud)
            {
                Console.WriteLine(item);
            }
        }

    }
}
