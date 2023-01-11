using System;
using static System.Console;

namespace MikaOS
{
    class MenuSystem
    {
        // This class is controlling the ability for the user in certain situations to control
        // the input by selecting options using the arrow keys instead of typing in a character.
        // It is essentially a constructor that works with a string array and console colors for highlighting.
        // This class can be easily called to any other class when necessary by using 3 lines of code. And then using a switch statement to make it work.
        // I didn't do this but I wrote it from a tutorial although I mostly understand the workings of it and know how to use it in diffirent contexts.

        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public MenuSystem(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        public void DisplayOptions()
        {
            Console.ForegroundColor = ConsoleColor.White;

            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i]; // Displays the current selected option?
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} << {currentOption} >>");
            }
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;

            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                // Update selectedIndex based on arrow keys.
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}