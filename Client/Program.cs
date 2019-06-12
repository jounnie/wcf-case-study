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

            Console.WriteLine("### FindAlbumsByTitle Rock\n");
            var albums = proxy.FindAlbumsByTitle("Rock");
            foreach (var album in albums)
            {
                Console.WriteLine(album);
            }
            
            Console.WriteLine("### FindTracksByTitle god\n");
            var tracks = proxy.FindTracksByTitle("god");
            foreach (var track in tracks)
            {
                Console.WriteLine(track);
            }
            
            Console.WriteLine("### FindAlbumsByInterpret AC/DC\n");
            var albums2 = proxy.FindAlbumsByInterpret("AC/DC");
            foreach (var album in albums2)
            {
                Console.WriteLine(album);
            }
            
            Console.WriteLine("### FindBoughtTracksByClient Leacock\n");
            var tracks2 = proxy.FindBoughtTracksByClient("Leacock");
            foreach (var track in tracks2)
            {
                Console.WriteLine(track);
            }
            
            Console.WriteLine("### FindInvoicesByClient Leacock\n");
            var invoices = proxy.FindInvoicesByClient("Leacock");
            foreach (var invoice in invoices)
            {
                Console.WriteLine(invoice);
            }
        }
    }
}
