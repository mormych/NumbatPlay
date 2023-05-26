using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbatPlay.App
{
    internal class FileManager
    {

        public static int OpenFile()
        {
            Console.Write("Enter path to MP3 file: ");
            string pathToFile = Console.ReadLine();

            if (pathToFile == null || pathToFile.Equals(""))
            {
                Console.WriteLine("Error: Path to file is null or empty");
                return -1;
            }

            if(CheckCorrect(pathToFile))
            {
                Console.WriteLine("Path to file is OK");
                Config.PathToFile = pathToFile;
                return 0;
            }
            else
            {
                return -2;
            }
        }

        public static int OpenDirectory()
        {
            Console.Write("Enter path to directory: ");
            string pathToDir = Console.ReadLine();

            if(!Directory.Exists(pathToDir))
            {
                Console.WriteLine("Directory not exist: " + pathToDir);
                return -3;
            }

            ReadFilesFromDir(pathToDir);
            return 0;

        }

        private static void ReadFilesFromDir(string pathToDir)
        {
            Config.FileArray = Directory.GetFiles(pathToDir, "*.mp3");

            Console.WriteLine("Files found: " + Config.FileArray.Length);
            foreach(var file in Config.FileArray)
            {
                Console.WriteLine("File: " + Path.GetFileName(file));
            }
        }

        private static Boolean CheckCorrect(string path)
        {
            if(!File.Exists(path))
            {
                Console.WriteLine("File not found");
                return false;
            } else if(!path.EndsWith(".mp3"))
            {
                Console.WriteLine("Unrecognized file format");
                return false;
            }

            return true;
        }

    }
}
