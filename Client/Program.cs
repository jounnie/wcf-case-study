using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceModel;
using WCFandEFService;


namespace ServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpointAddress = new EndpointAddress("http://localhost/WCFandEFService/ProductService");
           
            var proxy = ChannelFactory<IProductService>.CreateChannel(new BasicHttpBinding(), endpointAddress);

            Product product=proxy.GetProduct(1);

            string input = Console.ReadLine();

        }
    }
}
