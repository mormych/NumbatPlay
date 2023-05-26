using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbatPlay.App.Player
{
    internal class MP3Menu
    {
        public MP3Menu()
        {

        }

        public static void PrintMenu()
        {
            Console.Clear(); //First we clear screen to print a new menu

            Console.WriteLine("Current playing: " + Path.GetFileName(Config.PathToFile));

            Console.WriteLine();

            Console.WriteLine("1. Next song");
            Console.WriteLine("2. Previous song");
            Console.WriteLine("3. Pause");
            Console.WriteLine("4. Continue");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Stop and quit");
        }

        public static void ControlPlayer(WaveOutEvent outDevice)
        {
            PrintMenu();

            string action = Console.ReadLine();

            switch(action)
            {
                case "5":
                    {
                        return;
                    }

                case "6":
                    {
                        outDevice.Stop();
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Undefined option");
                        break;
                    }
            }
        }
    }
}
