using System.Dynamic;

namespace FinalProject
{
    internal class Program
    {
        const int SIZE = 100;
        static void Main(string[] args)
        {
            Membership[] members = new Membership[SIZE];
            for (int i = 0; i< SIZE;i++)
            {
                members[i] = new Membership();
            }
            int membersCounter = 0;
            Console.WriteLine("Welcome to our Running Club");
            int choice = Menu();
            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        if (membersCounter > 0)
                        {
                            for(int i=0; i<membersCounter; i++)
                            {
                                if (members[i].Id !=0)
                                       members[i].Print();
                            }                                
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You need to add members before you try to print them!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case 2:
                        AddMember(members,ref membersCounter);
                        break;
                    case 3:
                        if (membersCounter > 0)
                        {
                            ChangeMember(members, membersCounter);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You need to add members before you try to change them!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case 4:
                        if (membersCounter > 0)
                        {
                            DeleteMember(members, membersCounter);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You need to add members before you try to delete them!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    default:
                        Console.WriteLine("You made an invalid selection from the menu, please try again");
                        break;
                }
                choice = Menu();
            }
        }

        private static void AddMember(Membership[] members, ref int counter)
        {
            Console.Write("ID: ");
            members[counter].Id = ValidateInt(Console.ReadLine());
            Console.Write("First Name: ");
            members[counter].FirstName = ValidateString(Console.ReadLine());
            Console.Write("Last Name: ");
            members[counter].LastName = ValidateString(Console.ReadLine());
            Console.Write("Dues: ");
            members[counter].Dues = ValidateDouble(Console.ReadLine());
            Console.Write("Email: ");
            members[counter].Email = ValidateString(Console.ReadLine());
            Console.Write("Cell#: ");
            members[counter].CellPhone = ValidateString(Console.ReadLine());
            string tempInterest = "go";
            while(tempInterest.ToLower() != "quit")
            {
                Console.Write("Hobby (quit to end): ");
                tempInterest = ValidateString(Console.ReadLine());
                if (tempInterest.ToLower() == "quit")
                    continue;
                else
                    members[counter].Interests.Add(tempInterest);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The new member has been added");
            Console.ForegroundColor = ConsoleColor.White;
            counter++;
        }
        private static void ChangeMember(Membership[] members, int counter)
        {
            int indexNumber = FindMember(members, counter);
            Console.WriteLine($"Do you want to change {members[indexNumber].FirstName} {members[indexNumber].LastName} (yes to continue)?");
            string answer = ValidateString(Console.ReadLine());
            if(answer.ToLower() == "yes")
            {
                Console.Write("First Name: ");
                members[indexNumber].FirstName = ValidateString(Console.ReadLine());
                Console.Write("Last Name: ");
                members[indexNumber].LastName = ValidateString(Console.ReadLine());
                Console.Write("Dues: ");
                members[indexNumber].Dues = ValidateDouble(Console.ReadLine());
                Console.Write("Email: ");
                members[indexNumber].Email = ValidateString(Console.ReadLine());
                Console.Write("Cell#: ");
                members[indexNumber].CellPhone = ValidateString(Console.ReadLine());
                members[indexNumber].Interests.Clear();
                string tempInterest = "go";
                while (tempInterest.ToLower() != "quit")
                {
                    Console.Write("Hobby (quit to end): ");
                    tempInterest = ValidateString(Console.ReadLine());
                    if (tempInterest.ToLower() == "quit")
                        continue;
                    else
                        members[indexNumber].Interests.Add(tempInterest);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your information has been updated");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        private static void DeleteMember(Membership[] members, int counter)
        {
            int indexNumber = FindMember(members, counter);
            Console.WriteLine($"Do you want to delete {members[indexNumber].FirstName} {members[indexNumber].LastName} (yes to continue)?");
            string answer = ValidateString(Console.ReadLine());
            if (answer.ToLower() == "yes")
            {
                members[indexNumber].Id = 0;
                members[indexNumber].FirstName = "";
                members[indexNumber].LastName = "";
                members[indexNumber].Dues = 0;
                members[indexNumber].Email = "";
                members[indexNumber].CellPhone = "";
                members[indexNumber].Interests.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The membership information has been deleted");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static int FindMember(Membership[] members, int counter)
        {
            Console.WriteLine($"Please enter a member number between 1 - {counter}");
            int number = ValidateInt(Console.ReadLine());
            while(number < 0 || number > counter)
            {
                Console.WriteLine("You entered a number that is out of range, please try again");
                number = ValidateInt(Console.ReadLine());
            }
            number--;  // subtract 1 for index starting at zero
            return number;
        }
        public static int Menu()
        {
            Console.WriteLine("Please make a selection from our menu");
            Console.WriteLine($"1 - Print All\n2 - Add a Member\n3 - Change a Member\n4 - Delete a Member\n5 - Quit");
            string? input = Console.ReadLine();
            int selection;
            while(!int.TryParse(input, out selection))
            {
                Console.WriteLine($"Please enter a value between 1 - 5");
                input = Console.ReadLine();
            }
            return selection;
        }
        public static int ValidateInt(string input)
        {
            int output=0;
            while (!int.TryParse(input, out output))
            {
                Console.WriteLine($"Please enter a whole number");
                input = Console.ReadLine();
            }
            return output;
        }
        public static double ValidateDouble(string input)
        {
            double output = 0;
            while (!double.TryParse(input, out output))
            {
                Console.WriteLine($"Please enter a real number with decimal places");
                input = Console.ReadLine();
            }
            return output;
        }
        public static string ValidateString(string input)
        {
            while (String.IsNullOrEmpty(input)||String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine($"Please enter a value that is blank or spaces");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
