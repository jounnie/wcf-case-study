using System;
using System.ServiceModel;
using WCFandEFService;

namespace Client
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var endpointAddress = new EndpointAddress("http://localhost:8733/WCFandEFService/ProductService");
           
            var proxy = ChannelFactory<IProductService>.CreateChannel(new BasicHttpBinding(), endpointAddress);

            var albums = proxy.FindAlbumsByTitle("Rock");
            foreach (var album in albums)
            {
                Console.WriteLine(album);
            }
            
            var tracks = proxy.FindTracksByTitle("god");
            foreach (var track in tracks)
            {
                Console.WriteLine(track);
            }
        }
    }
}
