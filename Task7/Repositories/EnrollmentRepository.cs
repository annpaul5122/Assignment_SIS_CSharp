using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;
using Task7.Utility;

namespace Student_Info_System.Repositories
{
    internal class EnrollmentRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public EnrollmentRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public int GetStudent(int enrollment_id)
        {
            int student_id = 0;
            cmd.CommandText = "Select student_id from ENROLLMENTS where enrollment_id=@enroll_id";
            cmd.Parameters.AddWithValue("@enroll_id",enrollment_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                student_id = (int)reader["student_id"];
            }
            connect.Close();
            cmd.Parameters.Clear();
            return student_id;
        }

        public int GetCourse(int enrollment_id)
        {
            int course_id = 0;
            cmd.CommandText = "Select course_id from ENROLLMENTS where enrollment_id=@e_id";
            cmd.Parameters.AddWithValue("@e_id", enrollment_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                course_id = (int)reader["course_id"];
            }
            connect.Close();
            cmd.Parameters.Clear();
            return course_id;
        }

        public bool DuplicateEnrollmentExists(Enrollment enrollment)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from ENROLLMENTS where student_id=@s_id and course_id=@c_id";
            cmd.Parameters.AddWithValue("@s_id", enrollment.StudentId);
            cmd.Parameters.AddWithValue("@c_id", enrollment.CourseId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = (int)reader["total"];
            }
            connect.Close();
            cmd.Parameters.Clear();
            if (count > 1)
            {
                return true;
            }
            return false;
        }
    }
}
