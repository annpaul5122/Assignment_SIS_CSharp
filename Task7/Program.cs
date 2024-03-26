using Student_Info_System.Repositories;
using Student_Info_System.Models;
using System.Xml.Serialization;
using System.Transactions;
using Student_Info_System.Exceptions;
using Task7.StudentInformationSystem;

namespace Student_Info_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentInfoSystem menu = new StudentInfoSystem();
            menu.MainMenu();
        }
    }
}
