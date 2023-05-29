using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbatPlay.App.Player
{
    /*
     * TODO:
     * - Zrobic odtwarzanie całego folderu
     * 
     */

    internal class MP3Player
    {

        static AudioFileReader audioFile;
        static WaveOutEvent outputDevice = new WaveOutEvent();
        static public int counter = -1;
        static Thread playerThread;

        public static WaveOutEvent OutputDevice 
        {
            get
            {
                return outputDevice;
            }
        }

        public MP3Player()
        {

        }

        public static void Init()
        {
            if (Config.PathToFile == null)
            {
                Console.WriteLine("Sorry. Current file not exist.");
                Console.WriteLine("Trying to open a new file...");

                if (FileManager.OpenFile() != 0)
                {
                    Console.WriteLine("Player not working. Something problem with file.");
                    return;
                }
                Console.WriteLine("File opened...");
            }
            audioFile = new AudioFileReader(Config.PathToFile);
            playerThread = new Thread(Play);
            Console.WriteLine($"Playing... {MusicName(Config.PathToFile)}");
            playerThread.IsBackground = true; // This will allow to close all threads on application close
            playerThread.Start();
            MP3Menu.ControlPlayer();
        }

        private static void Play()
        {
            if(outputDevice.PlaybackState == PlaybackState.Playing)
            {
                outputDevice.Stop();

            }
            outputDevice.Init(audioFile);
            outputDevice.Play();

            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(1000);
            }
            if(outputDevice.PlaybackState == PlaybackState.Stopped && Config.FileArray.Count != 0) 
            {
                PlayPlaylist();
            }
        }

        public static void PlayPlaylist()
        {
            if(Config.FileArray.Count == 0)
            {
                Console.WriteLine("Unable to play playlist");
                Console.WriteLine("Reason: Playlist is empty");
                return;
            }
            if (counter >= Config.FileArray.Count)
            {
                Console.WriteLine("This is last song");
                return;
            }
            else if (counter < 0)
            {
                counter = 0;
            }
            audioFile = new AudioFileReader(Config.FileArray[counter]);
            Config.PathToFile = Config.FileArray[counter];

            playerThread = new Thread(Play);
            Console.WriteLine($"Playing... {MusicName(Config.PathToFile)}");
            playerThread.IsBackground = true; // This will allow to close all threads on application close
            playerThread.Start();
            counter++;
            MP3Menu.ControlPlayer();
        }

        private static string MusicName(string pathToFile)
        {
            return Path.GetFileName(pathToFile);
        }
    }
}
