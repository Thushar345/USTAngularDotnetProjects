using System.Text;
using System.Net;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebRequest request = WebRequest.Create("https://www.microsoft.com");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII);
            Console.WriteLine(reader.ReadToEnd());
        }
    }
}
