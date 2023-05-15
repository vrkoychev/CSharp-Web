namespace BasicWebServer
{
    using System.Net;
    using System.Net.Sockets;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var ipAdress = IPAddress.Parse("127.0.0.1");
            var port = 8080;
            var serverListener = new TcpListener(ipAdress, port);
            serverListener.Start();

            Console.WriteLine($"Server started on port {port}.");
            Console.WriteLine("Listening for requests...");

            var connection = serverListener.AcceptTcpClient();
        }
    }
}