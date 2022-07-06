using System.Net;
using System.Net.NetworkInformation;

namespace CorsoCSharp
{
    class _38_WorkingWithNetwork
    {
        static string url = @"https://world.episerver.com/cms/?q=pagetype";
        Uri uri = new Uri(url);

        public _38_WorkingWithNetwork()
        {
            Console.WriteLine($"URL: {url}");
            Console.WriteLine($"Schema: {uri.Scheme}");         // https
            Console.WriteLine($"Port: {uri.Port}");             // 443
            Console.WriteLine($"Host: {uri.Host}");             // world.episerver.com
            Console.WriteLine($"Path: {uri.AbsolutePath}");     // cms
            Console.WriteLine($"Query: {uri.Query}");           // ?q=pagetype

            IPHostEntry entry = Dns.GetHostEntry(uri.Host);     // world.episerver.com.cdn.cloudflare.net

            foreach (IPAddress address in entry.AddressList)
            {
                Console.WriteLine($"{address} ({address.AddressFamily})");                     // 104.18.23.198      104.18.22.198
            }
        }

        public void pingServer()
        {
            try
            {
                Ping ping = new();
                Console.WriteLine("Pinging server. Please wait....");

                PingReply reply = ping.Send(uri.Host);

                Console.WriteLine($"{uri.Host} was pinged and replied: {reply.Status}");

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine($"Reply from {0} took {1:N0}ms", reply.Address, reply.RoundtripTime);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
