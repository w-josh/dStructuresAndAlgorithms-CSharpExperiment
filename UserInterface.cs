using System;
namespace ToolLibrarySystem
{
    //Contains UI methods and formatting

    class UserInterface
    {
        //Fields for UI and Algorithms

        public static int newMemberSize = 0;
        public static int maxMemberSize = 10;
        public readonly Member[] newMember = new Member[maxMemberSize]; //registration amount if limited to 10 for the sake of brevity.
        MemberCollection register = new MemberCollection();
        LinkedList chain = new LinkedList();
        public static int minKey = 0;
        public static int maxKey = 10;
        public int[] keys = new int[maxKey];

        public void GetMainMenu()
        {
            Console.WriteLine("Welcome to the Tool Libray");
            Console.WriteLine();
            Console.WriteLine("========== MAIN MENU ==========");
            Console.WriteLine();
            Console.WriteLine("1 - Staff User");
            Console.WriteLine("2 - Member User");
            Console.WriteLine("3 - Exit");

            int choice;

            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    if (VerifyUser(choice))
                    {
                        GetStaffMenu(choice);
                    }
                    break;
                case 2:
                    Console.Clear();
                    GetMemberMenu();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    GetMainMenu();
                    break;
            }

        }
        //Staff menu methods

        void GetStaffMenu(int choice)
        {
            Console.WriteLine("========== STAFF MENU ==========\n");
            Console.WriteLine("========== STAFF - TOOL OPTIONS ==========\n");
            Console.WriteLine("1 - Add a tool to the Database");
            Console.WriteLine("2 - Remove a Tool from the Database\n");
            Console.WriteLine("========== STAFF - MEMBER OPTIONS ==========\n");
            Console.WriteLine("3 - Register member");
            Console.WriteLine("4 - Remove Member");
            Console.WriteLine("5 - Display Borrowing Members");
            Console.WriteLine("6 - Search Member");
            Console.WriteLine("0 - Return to Main Menu");

            int.TryParse(Console.ReadLine(), out choice); //Still to this day have no idea how this is supposed to work.

            switch (choice)
            {
                case 0:
                    Console.Clear();
                    GetMainMenu();
                    break;
                case 1:
                    Console.Clear();
                    //add tool to database. 
                    break;
                case 2:
                    Console.Clear();
                    //remove a tool from database.
                    break;
                case 3:
                    Console.Clear();
                    //Regiser a new member
                    RegisterMember();
                    break;
                case 4:
                    Console.Clear();
                    //RemoveMember();
                    //remove a member
                    break;
                case 5:
                    Console.Clear();
                    //Display members with tools > 1
                    break;
                case 6:
                    Console.Clear();
                    SearchMember();
                    //Search members by phone number and display their information
                    break;
                default:
                    Console.Clear();
                    GetStaffMenu(choice);
                    break;
            }

        }
        //Member menu methods

        void GetMemberMenu()
        {
            Console.WriteLine("========== MEMBER MENU ==========");
            Console.WriteLine("");
        }
        bool VerifyUser(int choice)
        {
            string user = "staff";
            string pass = "today123";

            Console.Write("Input Username: ");
            if (Console.ReadLine() != user)
            {
                Console.Clear();
                Console.WriteLine("INCORRECT STAFF USERNAME PROVIDED - RETURNING TO MAIN MENU");
                GetMainMenu();
            }
            Console.Write("Input Password: ");
            if (Console.ReadLine() != pass)
            {
                Console.Clear();
                Console.WriteLine("INCORRECT STAFF PASSWORD PROVIDED - RETURNING TO MAIN MENU");
                GetMainMenu();
            }
            Console.Clear();
            return true;
        }
        void RegisterMember()
        {

            if (newMember.Length >= newMemberSize)
            {
                newMember[newMemberSize] = new Member("", "", "", 0);
                Console.WriteLine("========== MEMBER REGISTRATION ==========\n");
                Console.Write("\nFirst Name: ");
                newMember[newMemberSize].FirstName = Console.ReadLine();
                Console.Write("\nLast Name: ");
                newMember[newMemberSize].LastName = Console.ReadLine();
                Console.Write("\nPassword: ");
                newMember[newMemberSize].Password = Console.ReadLine();
                Console.Write("\nPhone Number: ");
                newMember[newMemberSize].PhoneNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("\nNEW USER SUMMARY: ");
                Console.WriteLine("\nFirst Name: {0}", newMember[newMemberSize].FirstName);
                Console.WriteLine("Last Name: {0}", newMember[newMemberSize].LastName);
                Console.WriteLine("Password: {0}", newMember[newMemberSize].Password);
                Console.WriteLine("Phone Number {0}\n", newMember[newMemberSize].PhoneNumber);
                Console.ReadKey();

                register.HashInsert(newMember[newMemberSize].PhoneNumber);
                register.DisplayMembers(newMember[newMemberSize].FirstName, newMember[newMemberSize].LastName);
                Console.WriteLine("Member {0} Successfully Registered!", newMember[newMemberSize].FirstName);

                keys[minKey] = newMember[newMemberSize].PhoneNumber;

            }
            newMemberSize++;
            minKey++;

            GetMainMenu();

        }
        void SearchMember()
        {
            //Search implementation. Why is this so painful
            //Search returns by index. As a consequence, the chain of said index will be returned, providing all results similar to the search integer.

            Console.Write("Input Phone number to search: ");
            int a = int.Parse(Console.ReadLine());
            if (register.TableCheck(a))
            {
                int find = LinearKeySearch(keys, keys.Length, a); //this index will be identical to the relevant name in newMember
                register.TableSearch(a, newMember[find].FirstName, newMember[find].LastName); //returns only the first node in the chain.
                SearchMember();
            }
            else
            {
                int x = 0;
                Console.WriteLine("ERROR: NUMBER NOT FOUND - RETURNING TO STAFF MENU\n");
                GetStaffMenu(x);
            }
            

        }

        //search through keys for the Hash table lookup:

        public static int LinearKeySearch(int[] a, int n, int key) //implement this for chain?
        {
            int i = 0;

            while (i < n)
            {
                if (a[i] == key)
                    return i;
                i = i + 1;
            }
            return -1;
        }
    }




}




