using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Info_System.Models
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Student()
        {

        }


        public Student(int studentId,string firstName,string lastName,DateTime dateofbirth,string email,string phoneNumber) 
        { 
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            DateofBirth = dateofbirth;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{StudentId} {FirstName} {LastName} {DateofBirth} {Email} {PhoneNumber}";
        }


    }
}
