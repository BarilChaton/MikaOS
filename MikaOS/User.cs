using System;
using System.IO;
using System.Linq;

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
            string password = GetHiddenInput("Enter Password: ");
            Console.Clear();
            Console.SetCursorPosition(left, top);
            string confirmPassword = GetHiddenInput("Confirm Password: ");
            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.Write("Enter LastName: ");
            string lastName = Console.ReadLine();
            Console.Clear();

            string userID = GenerateUserID();

            while (CheckForExistID(userID))
            {
                userID = GenerateUserID();
            }

            User newUser = new User(userName, password, email, name, lastName, userID);

            SaveUser(newUser);
        }

        public static string GenerateUserID()
        {
            Random random = new Random();
            return random.Next(1000000, 9999999).ToString();
        }

        public static bool CheckForExistID(string id)
        {
            var lines = File.ReadLines("OSData/Users/users.mol").Skip(1);
            foreach (var line in lines)
            {
                if (line.Contains(id))
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetHiddenInput(string message)
        {
            Console.Write(message);
            string input = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    input += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return input;
        }


        public static void SaveUser(User user)
        {
            string path = "OSData/Users/users.mol";
            string userData = user.UserName + ":" + user.Password + ":" + user.Email + ":" + user.Name + ":" + user.LastName + ":" + user.UserID + "\n";
            File.AppendAllText(path, userData + Environment.NewLine);
        }
    }
}
