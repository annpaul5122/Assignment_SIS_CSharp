using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Info_System.Models
{
    internal class Payment
    {

        public int PaymentId { get; set; }
        public int? StudentId { get; set; }

        public int? Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment() { }


        public Payment(int paymentId, int studentId,int amount, DateTime paymentDate)
        {
            PaymentId = paymentId;
            StudentId = studentId;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        public override string ToString()
        {
            return $"{PaymentId} {StudentId} {Amount} {PaymentDate}";
        }
    }
}
