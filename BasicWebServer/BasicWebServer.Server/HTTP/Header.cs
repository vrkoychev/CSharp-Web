using BasicWebServer.Server.Common;

namespace BasicWebServer.Server.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            Guard.AgainstNull(name);
            Guard.AgainstNull(value);

            Name = name; 
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
