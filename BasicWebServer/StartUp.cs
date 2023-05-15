﻿namespace BasicWebServer
{
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

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
            var networkStream = connection.GetStream();
            var content = "Hello from my server!";
            var contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);
            networkStream.Write(responseBytes);
            connection.Close();
        }
    }
}