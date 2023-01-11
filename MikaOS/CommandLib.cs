using System;
using System.Collections.Generic;

namespace MikaOS
{
    public class CommandLib
    {
        // Dictionary to hold commands.
        public static readonly Dictionary<string, Action> _commands = new Dictionary<string, Action>();

        // Static constructor to add commands to the dictionary.
        static CommandLib()
        {
            AddCommand("hello", HelloWorld);
        }

        // Method to add a command to dictionary
        public static void AddCommand(string name, Action method)
        {
            _commands[name] = method;
        }

        // Command methods.
        public static void HelloWorld()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
