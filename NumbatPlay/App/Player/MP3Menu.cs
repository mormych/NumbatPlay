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

        public static void ControlPlayer()
        {
            PrintMenu();


            while(true)
            {
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        {
                            if (Config.FileArray.Count != 0)
                            {
                                MP3Player.PlayPlaylist();
                                PrintMenu();
                            }
                            else
                            {
                                Console.WriteLine("Unable to play next song");
                                Console.WriteLine("Reason: Playlist is empty");
                            }
                            break;
                        }

                    case "2":
                        {
                            if (Config.FileArray.Count != 0)
                            {
                                MP3Player.counter -= 2;
                                MP3Player.PlayPlaylist();
                                PrintMenu();
                            }
                            else
                            {
                                Console.WriteLine("Unable to play previous song");
                                Console.WriteLine("Reason: Playlist is empty");
                            }
                            break;
                        }
                    case "5":
                        {
                            return;
                        }

                    case "6":
                        {
                            MP3Player.OutputDevice.Stop();
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong option");
                            break;
                        }
                }
            }
        }
    }
}
