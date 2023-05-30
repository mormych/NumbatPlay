using NumbatPlay.App;

namespace NumbatPlay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logo();
            Application application = new Application(DateTime.Now);
            application.Start();
        }

        static void Logo()
        {
            Console.WriteLine("********NumbatSoftware********");
            Console.WriteLine("****Numbat player ver. 1.0****");
        }
    }
}