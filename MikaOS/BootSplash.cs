using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace MikaOS
{
    class BootSplash
    {    

        //This method is the entry point to this class.
        public static void RunBootupSequence()
        {
            CheckOsDir("OsData");
            Bootup();
        }

        // Method for checking for system directories.
        // If none existent then create them.
        public static void CheckOsDir(string dir)
        {
            int delay = 2;
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir);
            string[] systemSubDirs = { "Users", "System", "Apps" };

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Checking for system folder: " + dir + "...");
            ConstantMethods.Delay(delay);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine(dir + " created");
                CheckSubDir(path, systemSubDirs);
                CreateFile(Path.Combine(path, systemSubDirs[0]), ".users");
                ConstantMethods.Delay(delay);
            }
            else
            {
                Console.WriteLine(dir + " found!");
                CheckSubDir(path, systemSubDirs);
                CreateFile(Path.Combine(path, systemSubDirs[0]), ".users");
                ConstantMethods.Delay(delay);
            }
            Console.ResetColor();
        }

        // Method for checking for a directory sub directories(takes an array of strings).
        // If none existent then create them.
        public static void CheckSubDir(string parentDir, string[] subDir)
        {
            string checkMessage = "Checking for required files";

            foreach (string i in subDir) 
            {
                string subPath = Path.Combine(parentDir, i);
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
            }
            ConstantMethods.DotLoader(checkMessage);
        }

        // Method to create a file in one of the folders.
        public static void CreateFile(string directoryPath, string fileName)
        {
            //Construct the full path to the new file
            string filePath = Path.Combine(directoryPath, fileName);

            // Check if the folder exists
            if (Directory.Exists(directoryPath))
            {
                // Check if the file already exists
                if (!File.Exists(filePath))
                {
                    // Create the file
                    using (FileStream fs = File.Create(filePath))
                    {
                        // If you want to write something in the file, you can use the stream object
                        string text = "Users: " + Environment.NewLine;
                        byte[] bytes = new UTF8Encoding(true).GetBytes(text);
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public static void Bootup()
        {
            int delay = 4;
            string asciiArt = "######################\n#--,_-----_----------#\n#---|\\_,-~/----------#\n#--/ _  _ |----,--.--#\n#-(  @  @ )---/ ,-'--#\n#--\\  _T_/-._( (-----#\n#--/         `. \\----#\n#-|         _  \\ |---#\n#--\\ \\ ,  /      |---#\n#---|| |-_\\__   /----#\n#--((_/`(____,-'-----#\n#--------------------#\n######################";

            Console.Clear();
            string[] asciiArtLines = asciiArt.Split('\n');

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor= ConsoleColor.DarkYellow;

            int top = Console.WindowHeight / 2 - (asciiArt.Split('\n').Length / 2);
            foreach (string line in asciiArtLines)
            {
                int left1 = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(left1, top);
                Console.Write(line);

                top++;
            }

            Console.ResetColor();

            top += 2;
            int left = (Console.WindowWidth - "Loading MikaOS".Length) / 2;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            // Set the cursor position and display the loading bar
            Console.SetCursorPosition(left, top);
            Console.Write("Loading MikaOS\n");
            top++;
            Console.SetCursorPosition(left, top);
            for (int i = 0; i < 14; i++)
            {
                Console.Write("#");
                System.Threading.Thread.Sleep(350);
            }
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(350);
            }
            Console.Clear();
            int topWelcome = Console.WindowHeight / 2;
            int leftWelcome = (Console.WindowWidth - "Welcome to MikaOS. Meow!".Length) / 2;
            Console.SetCursorPosition(leftWelcome, topWelcome);
            Console.WriteLine("Welcome to MikaOS. Meow!");
            ConstantMethods.Delay(delay);
            Console.Clear();
            Console.SetCursorPosition(leftWelcome, topWelcome);
            ConstantMethods.CheckForUsers();
            Console.ResetColor();
            Program.AfterBoot();
        }
    }
}
