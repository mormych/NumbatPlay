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

        public static void PrintMenu(bool paused = false)
        {
            Console.Clear(); //First we clear screen to print a new menu

            if(paused)
            {
                Console.WriteLine("Paused: " + Path.GetFileName(Config.PathToFile));
            }
            else
            {
                Console.WriteLine("Current playing: " + Path.GetFileName(Config.PathToFile));
            }
            Console.WriteLine();

            Console.WriteLine("1. Next song");
            Console.WriteLine("2. Previous song");
            Console.WriteLine("3. Pause");
            Console.WriteLine("4. Continue");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Stop and quit");
        }

        public static void ControlPlayer(bool singleFile = false)
        {
            while(true)
            {
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1" when !singleFile:
                        {
                            MP3Player.OutputDevice.Stop();
                            break;
                        }

                    case "2" when !singleFile:
                        {
                            if(MP3Player.songMarker == 0)
                            {
                                PrintMenu();
                                break;
                            }
                            MP3Player.songMarker -= 2;
                            MP3Player.OutputDevice.Stop();
                            break;
                        }
                    case "3":
                        {
                            MP3Player.OutputDevice.Pause();
                            PrintMenu(true);
                            break;
                        }

                    case "4":
                        {
                            MP3Player.OutputDevice.Play();
                            PrintMenu();
                            break;
                        }
                    case "5":
                        {
                            return;
                        }

                    case "6":
                        {
                            MP3Player.songMarker = Config.FileArray.Count;
                            MP3Player.OutputDevice.Stop();
                            MP3Player.playerThread.Join(); //Waiting for complete task player thread
                            return;
                        }
                    default:
                        {
                            if(singleFile)
                            {
                                Console.WriteLine("Option not allowed in single file mode player");
                            }
                            else
                            {
                                Console.WriteLine("Undefined option");
                            }
                            break;
                        }
                }
            }
        }
    }
}
