using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Info_System.Models;

namespace Student_Info_System.Exceptions
{
    internal class PaymentValidationException : Exception
    {
        public PaymentValidationException(string message): base(message)
        {
            
        }

        public static void PaymentError(Payment payment)
        {
            if(payment.Amount<=0)
            {
                throw new PaymentValidationException("Payment amount invalid!!");
            }
            else if(payment.PaymentDate > DateTime.Now)
            {
                throw new PaymentValidationException("Payment date invalid!!");
            }
        }
    }
}
