using System;
using System.Runtime.InteropServices;

namespace MikaOS
{
    class Program
    {
        // This sets up so the console will go full screen.
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        static void Main(string[] args)
        {
            // Apply Fullscreen. (Does only work for windows system.)
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            // Start Bootup, this will load all files in the future.
            BootSplash.RunBootupSequence();
        }

        public static void AfterBoot()
        {
            Console.Clear();
            Console.WriteLine("OS Booted!");
            Console.ReadLine();
        }
    }
}
