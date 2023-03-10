using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikaOS
{
    class ConstantMethods
    {
        // Delay timer method (takes int number of seconds.)
        public static void Delay(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                System.Threading.Thread.Sleep(1000);
            }
        }

        // A dot loader.
        public static void DotLoader(string currentMessage)
        {
            string[] loadDots = { " ", ".", "..", "..." };
            string message = currentMessage;

            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            int secondsCount = 0;

            Console.Write(message);
            while (true)
            {
                Console.CursorVisible = false;
                for (int i = 0; i < loadDots.Length; i++)
                {
                    Console.SetCursorPosition(x + message.Length, y);
                    Console.Write(loadDots[i]);
                    System.Threading.Thread.Sleep(350);

                    if (loadDots[i] == "...")
                    {
                        Console.SetCursorPosition(x + message.Length, y);
                        Console.Write("    ");
                    }
                    secondsCount += 2857;
                }
                // This is 5 seconds lol...
                if (secondsCount >= 14285)
                {
                    break;
                }
            }
        }

        public static void CheckForUsers()
        {
            string userListPath = "OSData/Users/.users";
            string currentDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDir, userListPath);

            if (File.ReadLines(userListPath).Skip(1).Count() == 0)
            {
                Console.WriteLine("No users detected...");
                Delay(2);
                Console.Clear();
                Console.WriteLine("Lets create one now!");
                Delay(2);
                User.CreateUser();
            }
            else
            {
                Console.WriteLine("There are users.");
                Delay(2);
            }
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

        // Folder creation

        // File creation
    }
}
