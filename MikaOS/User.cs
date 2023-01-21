using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MikaOS
{
    class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserID { get; set; }

        public User(string userName, string password, string email, string name, string lastname, string userID) 
        {
            UserName = userName;
            Password = password;
            Email = email;
            Name = name; 
            LastName = lastname;
            UserID = userID;
        }

        public static void CreateUser()
        {
            int top = Console.WindowHeight / 2;
            int left = Console.WindowWidth / 2 - 16;

            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.Write("Enter Username: ");
            string userName = Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(left, top);
            string password = ConstantMethods.GetHiddenInput("Enter Password: ");
            Console.Clear();
            Console.SetCursorPosition(left, top);
            string confirmPassword = ConstantMethods.GetHiddenInput("Confirm Password: ");

            //Check for password validation.
            while (password != confirmPassword)
            {
                Console.Clear();
                Console.SetCursorPosition(left, top);
                Console.WriteLine("Passwords do not match. Please re-enter your password:");
                password = ConstantMethods.GetHiddenInput("Enter Password: ");
                Console.Clear();
                Console.SetCursorPosition(left, top);
                confirmPassword = ConstantMethods.GetHiddenInput("Confirm Password: ");
            }

            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.Write("Enter Email: ");
            string email = CheckEmailFormat(Console.ReadLine());
            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.Write("Enter Lastname: ");
            string lastName = Console.ReadLine();
            Console.Clear();

            string userID = GenerateUserID();

            while (CheckForExistID(userID))
            {
                userID = GenerateUserID();
            }

            User newUser = new User(userName, confirmPassword, email, name, lastName, userID);

            SaveUser(newUser);
        }

        public static string CheckEmailFormat(string email)
        {
            int top = Console.WindowHeight / 2;
            int left = Console.WindowWidth / 2 - 16;

            const string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
            {
                Console.SetCursorPosition(left, top);
                Console.Write("Invalid email format, Please re-enter yout email: ");
                email = Console.ReadLine();
                return CheckEmailFormat(email);
            }
            else
            {
                return email;
            }
        }

        public static string GenerateUserID()
        {
            Random random = new Random();
            return random.Next(1000000, 9999999).ToString();
        }

        public static bool CheckForExistID(string id)
        {
            var lines = File.ReadLines("OSData/Users/.users").Skip(1);
            foreach (var line in lines)
            {
                if (line.Contains(id))
                {
                    return true;
                }
            }
            return false;
        }


        public static void SaveUser(User user)
        {
            string path = "OSData/Users/.users";
            string userData = user.UserName + ":" + user.Password + ":" + user.Email + ":" + user.Name + ":" + user.LastName + ":" + user.UserID + "\n";
            File.AppendAllText(path, userData + Environment.NewLine);
        }
    }
}
