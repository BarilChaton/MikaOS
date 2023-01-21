using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikaOS
{
    class Login
    {
        public static bool VerifyCredentials(string username, string password)
        {
            string path = "OSData/Users/.users";
            string[] userData = File.ReadAllLines(path);
            foreach (string line in userData)
            {
                string[] parts = line.Split(':');
                if (parts[0] == username && parts[1] == password) 
                    return true;
            }
            return false;
        }

        public static void RunLoginSequence()
        {
            int top = Console.WindowHeight / 2 - 3;
            int left = Console.WindowWidth / 2 - 16;

            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.WriteLine("Login.");
            Console.SetCursorPosition(left, top);
            Console.Write("Enter Username: ");
            Console.SetCursorPosition(left, top + 1);
            string username = Console.ReadLine();
            Console.SetCursorPosition(left, top + 2);
            Console.Write("Enter Password: ");
            Console.SetCursorPosition(left, top + 3);
            string password = ConstantMethods.GetHiddenInput("");

            if (VerifyCredentials(username, password))
            {
                Console.Clear();
                Console.SetCursorPosition(left, top);
                Console.WriteLine("Logging you in, Meow!");
                ConstantMethods.Delay(3);
                Console.Clear();
                Console.SetCursorPosition(left, top);
                Console.WriteLine("Login Successfull! Meow!");
                ConstantMethods.Delay(3);
                Console.Clear();
                Program.AfterBoot();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(left, top);
                Console.WriteLine("Logging you in, Meow!");
                ConstantMethods.Delay(3);
                Console.Clear();
                Console.SetCursorPosition(left, top);
                Console.WriteLine("Login not successfull, try again!");
                ConstantMethods.Delay(3);
                RunLoginSequence();
            }
        }
    }
}
