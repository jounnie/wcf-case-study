using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceModel;
using DemoSqlServer;
using WCFandEFService;


namespace ServiceClient
{
    class Program
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
