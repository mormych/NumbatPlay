using NAudio.Wave;
using NumbatPlay.App.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbatPlay.App
{
    internal class Application
    {
        /// <summary>
        /// Entry point for MP3 Player app
        /// </summary>
        /// <returns>0 if everything was alright</returns>
        /// 

        private DateTime LaunchDate;

        public Application(DateTime launchDate)
        {
            LaunchDate = launchDate;
        }


        public int Start()
        {
            bool end = false;
            while(!end)
            {
                ShowMenu();
                int.TryParse(Console.ReadLine(), out int option);

                switch (option)
                {
                    case 1:
                        {
                            MP3Player.Init();
                            break;
                        }
                    case 2:
                        {
                            FileManager.OpenFile();
                            break;
                        }
                    case 3:
                        {
                            FileManager.OpenDirectory();
                            break;
                        }

                    case 4:
                        {
                            MP3Player.PlayPlaylist();
                            break;
                        }
                    case 9 when MP3Player.OutputDevice.PlaybackState == PlaybackState.Playing:
                        {
                            MP3Menu.ControlPlayer();
                            break;
                        }

                       
                    case 10:
                        {
                            end = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Undefined option");
                            break;
                        }
                }
            }
            return 0;
        }



        private void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Play current MP3 file");
            Console.WriteLine("2. Read MP3 file");
            Console.WriteLine("3. Read MP3 directory");
            Console.WriteLine("4. Play current Playlist");
            if(MP3Player.OutputDevice != null && MP3Player.OutputDevice.PlaybackState == PlaybackState.Playing)
            {
                Console.WriteLine("9. Return to control panel");
            }
            Console.WriteLine("10. Save & exit");
        }

    }
}
