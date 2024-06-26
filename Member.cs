using System;
namespace ToolLibrarySystem
{
    public class Member
    {

        //Member class containing constructor for members.

        private string _firstName;
        private string _lastName;
        private string _password;
        private int _phoneNumber;

        public Member(string firstName, string lastName, string password, int phoneNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _password = password;
            _phoneNumber = phoneNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }

        public Member()
        {

        }

    }


}