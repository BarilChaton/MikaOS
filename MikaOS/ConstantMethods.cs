using System;
using System.Collections.Generic;
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
        public static void DotLoader()
        {
            string[] loadDots = { " ", ".", "..", "..." };
            string message = "Checking for sub directories";

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

        // Folder creation

        // File creation
    }
}
