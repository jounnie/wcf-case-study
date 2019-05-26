using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DemoSqlServer;

namespace WCFandEFService
{
    public class ProductService : IProductService
    {
        public void AddAlbumWithTracks()
        {
            ChinookEntities context = new ChinookEntities();
            var query = from p
                    in context.Album.AsEnumerable()
                select p;
            var albums = query.ToArray();

            foreach (var album in albums)
            {
                Console.WriteLine(album.Title);
            }
        }

        public void DeleteAlbum(int id)
        {
            throw new NotImplementedException();
        }

        public List<Album> FindAlbumsByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<Track> FindTracksByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<Album> FindAlbumsByInterpret(string interpret)
        {
            throw new NotImplementedException();
        }

        public List<Track> FindBoughtTracksByClient(string client)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> FindInvoicesByClient(string client)
        {
            throw new NotImplementedException();
        }
    }
}