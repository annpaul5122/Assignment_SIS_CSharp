using System;
using Student_Info_System.Models;

namespace Student_Info_System.Repositories
{
    internal class PaymentRepository
    {
        public static List<Payment> payments =new List<Payment>();

        public void InsertDetails(Payment payment)
        {
            payments.Add(payment);
        }

        public void GetStudent(int StudentId)
        {
           
            foreach (Student item in StudentRepository.stud)
            {
                if(item.StudentId == StudentId)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void GetPaymentAmount(int PaymentId)
        {
            foreach(Payment item in payments)
            {
                if(item.PaymentId == PaymentId)
                {
                    Console.WriteLine(item.Amount);
                }
            }
        }

        public void GetPaymentdate(int PaymentId)
        {
            foreach (Payment item in payments)
            {
                if (item.PaymentId == PaymentId)
                {
                    Console.WriteLine(item.PaymentDate);
                }
            }
        }

        public void displayDetails()
        {
            foreach (Payment item in payments)
            {
                Console.WriteLine(item);
            }
        }

    }
}
