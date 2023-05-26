using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbatPlay.App.Player
{
    internal class MP3Player
    {

        AudioFileReader audioFile;
        WaveOutEvent outputDevice;

        public WaveOutEvent OutputDevice
        {
            get
            {
                return outputDevice;
            }
        }

        public MP3Player()
        {
            outputDevice = new WaveOutEvent();
        }

        public void Init()
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
            Thread playerThread = new Thread(Play);
            Console.WriteLine($"Playing... {MusicName(Config.PathToFile)}");
            playerThread.IsBackground = true; // This will allow to close all threads on application close
            playerThread.Start();
            MP3Menu.ControlPlayer(outputDevice);
        }

        private void Play()
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
        }

        private string MusicName(string pathToFile)
        {
            return Path.GetFileName(pathToFile);
        }
    }
}
