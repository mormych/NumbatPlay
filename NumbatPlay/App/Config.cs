using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbatPlay.App
{
    internal class Config
    {
        private static string? pathToFile = null;
        private static List<string> fileArray = new();

        public static string PathToFile
        {
            get
            {
                return pathToFile;
            }
            set
            {
                pathToFile = value;
            }
        }

        public static List<string> FileArray
        {
            get
            {
                return fileArray;

            }
            set
            {
                fileArray = value;
            }
        }
    }
}
