using System;
using System.Data.SqlClient;
using Student_Info_System.Models;
using Task7.Utility;

namespace Student_Info_System.Repositories
{
    internal class PaymentRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public PaymentRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public Payment GetStudent(int paymentId)
        {
            Payment payment = new Payment();
            cmd.CommandText = "Select * from PAYMENTS where payment_id=@p_id";
            cmd.Parameters.AddWithValue("@p_id", paymentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                payment.PaymentId = (int)reader["payment_id"];
                payment.StudentId = Convert.IsDBNull(reader["student_id"])?null:(int)reader["student_id"];
                payment.Amount = Convert.IsDBNull(reader["amount"])?null:(int)reader["amount"];
                payment.PaymentDate = (DateTime)reader["payment_date"];
            }
            connect.Close();
            cmd.Parameters.Clear();
            return payment;
        }

        public int GetPaymentAmount(int paymentId)
        {
            int amount = 0;
            cmd.CommandText = "Select amount from PAYMENTS where payment_id=@pid";
            cmd.Parameters.AddWithValue("@pid", paymentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                amount = (int)reader["amount"];
            }
            connect.Close();
            cmd.Parameters.Clear();
            return amount;
        }

        public DateTime GetPaymentdate(int paymentId)
        {
            DateTime date = DateTime.MinValue;
            cmd.CommandText = "Select payment_date from PAYMENTS where payment_id=@payment_id";
            cmd.Parameters.AddWithValue("@payment_id", paymentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                date = (DateTime)reader["payment_date"];
            }
            connect.Close();
            cmd.Parameters.Clear();
            return date;
        }

    }
}
