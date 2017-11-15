using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Conference_Barcode_Console
{
    class Program
    {
        

        static void Main(string[] args)
        {
            mainMenu();

        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            //change text color
            Console.ForegroundColor = color;

            //tell user not a number
            Console.WriteLine(message);

            //reset color
            Console.ResetColor();
        }

        static void mainMenu()
        {
            string version = "1.0.0";
            int selection;

            Console.Clear();
            Console.WriteLine("Version: " + version);
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1.) Scan");
            Console.WriteLine("2.) Stats");
            Console.WriteLine("3.) Settings");
            while (true)
            {
                String input = Console.ReadLine();

                if (!int.TryParse(input, out selection))
                {
                    PrintColorMessage(ConsoleColor.Red, "Please select a number");
                }
                if ((selection < 0) | (selection > 4))
                    PrintColorMessage(ConsoleColor.Red, "Selection out of range");

                switch (selection)
                {
                    case 1:
                        scanMenu();
                        break;
                    case 2:
                        statsMenu();
                        break;
                    case 3:
                        settingsMenu();
                        break;
                }
            }
        }

        static void scanMenu()
        {
            int selection;

            Console.Clear();
            Console.WriteLine("Scanning Menu:");
            Console.WriteLine("1.) Door Scanning");
            Console.WriteLine("2.) T-Shirt Scanning");
            Console.WriteLine("3.) Back");

            while (true)
            {
                String input = Console.ReadLine();

                if (!int.TryParse(input, out selection))
                {
                    PrintColorMessage(ConsoleColor.Red, "Please select a number");
                }
                if ((selection < 0) | (selection > 4))
                    PrintColorMessage(ConsoleColor.Red, "Selection out of range");

                switch (selection)
                {
                    case 1:
                        doScan();
                        break;
                    case 2:
                        doTickets();
                        break;
                    case 3:
                        mainMenu();
                        break;
                }
            }
        }
        static void statsMenu()
        {
            Console.Clear();
            Console.WriteLine("Stats Menu:");
            Console.WriteLine("1.) View");
            Console.WriteLine("2.) Export");
            Console.WriteLine("3.) Back");
        }
        static void settingsMenu()
        {
            Console.Clear();
            Console.WriteLine("Settings Menu:");
            Console.WriteLine("1.) Door Setup");
            Console.WriteLine("2.) Validation");
            Console.WriteLine("3.) Screen Mode");
            Console.WriteLine("4.) Back");
        }
        static void doScan()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = @"C:\Users\doug\Documents\Projects\Conference 2018\Barcode App\Conference Barcode Console\bin\Debug\smb3_coin.wav";
            

            Console.Clear();
            Console.WriteLine("Door Scanning:");



            string time = DateTime.Now.ToString("HH:mm:ss tt");
            string input = Console.ReadLine();

            Console.WriteLine(input);

            string sampleText = String.Format("Door: {0}{1}Date:{2}{3}", "A1", Environment.NewLine, "11/15/2017", Environment.NewLine);

            File.WriteAllText(@"testData.txt",sampleText);
            
            while (true)
            {
                string scandata = Console.ReadLine();
                

                File.AppendAllText("testData.txt", string.Format("{0},{1}{2}",time,scandata,Environment.NewLine));
                //player.PlaySync();

                Console.Beep();
                
            }
            



        }
        static void doTickets()
        {
            Console.Clear();
            Console.WriteLine("Ticket Scanning:");
        }

    }
}
