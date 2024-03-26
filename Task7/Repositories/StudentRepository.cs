using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;
using Task7.Utility;

namespace Student_Info_System.Repositories
{
    internal class StudentRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public StudentRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public void InsertRecords(Student students)
        {
            cmd.CommandText = "Insert into STUDENTS values(@fname,@lname,@dob,@email,@phno)";
            cmd.Parameters.AddWithValue("@fname", students.FirstName);
            cmd.Parameters.AddWithValue("@lname", students.LastName);
            cmd.Parameters.AddWithValue("@dob", students.DateofBirth);
            cmd.Parameters.AddWithValue("@email", students.Email);
            cmd.Parameters.AddWithValue("@phno", students.PhoneNumber);
            connect.Open();
            cmd.Connection= connect;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
        }

        public void EnrollInCourse(Course course,int studentId)
        {
            cmd.CommandText = "Insert into ENROLLMENTS values(@s_id,@c_id,@date)";
            cmd.Parameters.AddWithValue("@s_id",studentId);
            cmd.Parameters.AddWithValue("@c_id",course.CourseId);
            cmd.Parameters.AddWithValue("@date",DateTime.Now);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
        }

        public void UpdateStudentInfo(Student students)
        {
            cmd.CommandText = "Update STUDENTS set first_name=@fname,last_name=@lname,date_of_birth=@dob,email=@email,phone_number=@phno where student_id=@id";
            cmd.Parameters.AddWithValue("@id", students.StudentId);
            cmd.Parameters.AddWithValue("@fname", students.FirstName);
            cmd.Parameters.AddWithValue("@lname", students.LastName);
            cmd.Parameters.AddWithValue("@dob", students.DateofBirth);
            cmd.Parameters.AddWithValue("@email", students.Email);
            cmd.Parameters.AddWithValue("@phno", students.PhoneNumber);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
        }

        public void MakePayment(int studentId,decimal amount)
        {
            cmd.CommandText = "Insert into PAYMENTS values(@s_id,@amount,@date)";
            cmd.Parameters.AddWithValue("@s_id", studentId);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
        }
        
        public List<Enrollment> GetEnrolledCourses(int s_id)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            cmd.CommandText = "Select * from ENROLLMENTS where student_id=@studentid";
            cmd.Parameters.AddWithValue("@studentid", s_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Enrollment enrollment = new Enrollment();
                enrollment.EnrollmentId = (int)reader["enrollment_id"];
                enrollment.StudentId = Convert.IsDBNull(reader["student_id"]) ? null : (int)reader["student_id"];
                enrollment.CourseId = Convert.IsDBNull(reader["course_id"])?null: (int)reader["course_id"];
                enrollment.EnrollmentDate = (DateTime)reader["enrollment_date"];
                enrollments.Add(enrollment);
            }
            connect.Close();
            cmd.Parameters.Clear();
            return enrollments;
        }

        public List<Payment> GetPaymentHistory(int s_id)
        {
            List<Payment> payments = new List<Payment>();
            cmd.CommandText = "Select * from PAYMENTS where student_id=@sid";
            cmd.Parameters.AddWithValue("@sid", s_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Payment payment = new Payment();
                payment.PaymentId = (int)reader["payment_id"];
                payment.StudentId = Convert.IsDBNull(reader["student_id"])?null:(int)reader["student_id"];
                payment.Amount = Convert.IsDBNull(reader["amount"])?null:(int)reader["amount"];
                payment.PaymentDate = (DateTime)reader["payment_date"];
                payments.Add(payment);
            }
            connect.Close();
            cmd.Parameters.Clear();
            return payments;
        }
        public List<Student> DisplayStudentInfo()
        {
            List<Student> students = new List<Student>();
            cmd.CommandText = "Select * from STUDENTS";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.StudentId = (int)reader["student_id"];
                student.FirstName = (string)reader["first_name"];
                student.LastName = (string)reader["last_name"];
                student.DateofBirth = (DateTime)reader["date_of_birth"];
                student.Email = (string)reader["email"];
                student.PhoneNumber = (string)reader["phone_number"];
                students.Add(student);
            }
            connect.Close();
            cmd.Parameters.Clear();
            return students;    
        }

        public bool StudentExists(int studentId)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from STUDENTS where student_id=@s_id";
            cmd.Parameters.AddWithValue("@s_id", studentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = (int)reader["total"];
            }
            connect.Close();
            cmd.Parameters.Clear();
            if (count > 0)
            {
                return true;
            }
            return false;

        }

    }
}
