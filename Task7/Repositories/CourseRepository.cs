using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;
using Task7.Utility;

namespace Student_Info_System.Repositories
{
    internal class CourseRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public CourseRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void AssignTeacher(Teacher teacher,Course course)
        {
            cmd.CommandText = "Update COURSES set teacher_id=@id where course_id=@c_id and teacher_id is null";
            cmd.Parameters.AddWithValue("@id", teacher.TeacherId);
            cmd.Parameters.AddWithValue("@c_id",course.CourseId);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
        }

        public List<Enrollment> GetEnrollments(int c_id)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            cmd.CommandText = "Select * from ENROLLMENTS where course_id=@c_id";
            cmd.Parameters.AddWithValue("@c_id",c_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Enrollment enrollment = new Enrollment();
                enrollment.EnrollmentId = (int)reader["enrollment_id"];
                enrollment.StudentId = Convert.IsDBNull(reader["student_id"])?null:(int)reader["student_id"];
                enrollment.CourseId = Convert.IsDBNull(reader["course_id"])?null:(int)reader["course_id"];
                enrollment.EnrollmentDate = (DateTime)reader["enrollment_date"];
                enrollments.Add(enrollment);
            }
            connect.Close();
            cmd.Parameters.Clear();
            return enrollments;
        }

        public List<string> GetTeacher(string course_name)
        {
            List<string> teacher = new List<string>();
            cmd.CommandText = "Select CONCAT_WS(' ',first_name,last_name) as Teacher from TEACHER t join COURSES c on t.teacher_id=c.teacher_id where c.course_name=@c_name";
            cmd.Parameters.AddWithValue("@c_name", course_name);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                string teachername = (string)reader["Teacher"];
                teacher.Add(teachername);
            }
            connect.Close();
            cmd.Parameters.Clear();
            return teacher;
        }

        public void UpdateCourseInfo(Course course)
        {
            cmd.CommandText = "Update COURSES set course_name=@name,credits=@credit,teacher_id=@t_id where course_id=@c_id";
            cmd.Parameters.AddWithValue("@name", course.CourseName);
            cmd.Parameters.AddWithValue("@credit", course.Credits);
            cmd.Parameters.AddWithValue("@t_id", course.InstructorId);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
        }

        public List<Course> DisplayCourseInfo()
        {
            List<Course> courses = new List<Course>();
            cmd.CommandText = "Select * from COURSES";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Course course = new Course();
                course.CourseId = (int)reader["course_id"];
                course.CourseName = (string)reader["course_name"];
                course.Credits = Convert.IsDBNull(reader["credits"]) ? null : (int)reader["credits"];
                course.InstructorId = Convert.IsDBNull(reader["teacher_id"])?null: (int)reader["teacher_id"];
                courses.Add(course);
            }
            connect.Close();
            cmd.Parameters.Clear();
            return courses;
        }
         
        public bool CourseExists(Course course)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from COURSES where course_id=@c_id";
            cmd.Parameters.AddWithValue("@c_id",course.CourseId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               count = (int)reader["total"];
            }
            connect.Close();
            cmd.Parameters.Clear();
            if (count>0)
            {
                return true;
            }
            return false;
        }

    }
}
