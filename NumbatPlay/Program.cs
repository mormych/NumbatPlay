using NumbatPlay.App;

namespace NumbatPlay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application(DateTime.Now);
            Logo();
            application.Start();
        }

        static void Logo()
        {
            Console.WriteLine("********NumbatSoftware********");
            Console.WriteLine("**Numbat player ver. 0.5BETA**");
        }
    }
}