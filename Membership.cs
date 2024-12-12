using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Membership
    {
        public int Id {  get; set; }
        public string? FirstName { get; set; }
        public string LastName { get; set; }=String.Empty;
        public double Dues {  get; set; }
        public string Email { get; set; } = String.Empty;
        public string? CellPhone { get; set; }
        public List<string> Interests { get; set; }=new List<string>();

        public Membership() 
        {
            Id = 0;
            FirstName = String.Empty;
            LastName = String.Empty;
            Dues = 0;
            Email = String.Empty;
            CellPhone = String.Empty;
            Interests = new List<string>();
        }
        public Membership(int id, string firstname, string lastname, double dues, string email, string cellphone, List<string> interests)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Dues = dues;
            Email = email;
            CellPhone = cellphone;
            Interests = interests;
        }
        public void Print()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"ID: {Id}    Name: {FirstName} {LastName}   Dues: {Dues:C}");
            Console.WriteLine($"Email: {Email}  Cell: {CellPhone}");
            Console.WriteLine();
            Console.WriteLine("      ------------Interest Areas------------       ");
            foreach(string i in Interests) 
                Console.WriteLine(i);
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
