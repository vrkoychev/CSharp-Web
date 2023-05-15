namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;

            Headers.Add("Server", "My Web Server");
            Headers.Add("Date", $"{DateTime.UtcNow:r}");
        }

        public StatusCode StatusCode { get; set; }
        public HeaderCollection Headers { get; set; } = new HeaderCollection();
        public string Body { get; set; }
    }
}
