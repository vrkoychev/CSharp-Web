namespace BasicWebServer.Server
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class HttpServer
    {
        private readonly IPAddress ipAdress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string ipAdress, int port)
        {
            this.ipAdress = IPAddress.Parse(ipAdress);
            this.port = port;

            serverListener = new TcpListener(this.ipAdress, port);
        }

        public void Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server started on port {port}...");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                var requestText = ReadRequest(networkStream);

                Console.WriteLine(requestText);

                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, string message)
        {
            var contentLength = Encoding.UTF8.GetByteCount(message);

            var response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{message}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            networkStream.Write(responseBytes);
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bufferLength));
            }
            while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}
