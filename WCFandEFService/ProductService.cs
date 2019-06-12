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
        private readonly ChinookEntities _context;

        public ProductService()
        {
            _context = new ChinookEntities();
        }

        public void AddAlbumWithTracks()
        {
            var query = from p
                    in _context.Album.AsEnumerable()
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

        public List<AlbumDto> FindAlbumsByTitle(string title)
        {
            var albums = _context.Album
                .Where(album => album.Title.Contains(title))
                .ToList();

            var results = new List<AlbumDto>();
            foreach (var album in albums)
            {
                results.Add(new AlbumDto {Title = album.Title});
            }

            return results;
        }

        public List<TrackDto> FindTracksByTitle(string title)
        {
            var tracks = _context.Track
                .Where(track => track.Name.Contains(title))
                .ToList();

            var results = new List<TrackDto>();
            foreach (var track in tracks)
            {
                results.Add(new TrackDto {
                    TrackId = track.TrackId, 
                    Name = track.Name,
                    AlbumId = track.AlbumId,
                    MediaTypeId = track.MediaTypeId,
                    GenreId = track.GenreId,
                    Composer = track.Composer,
                    Milliseconds = track.Milliseconds,
                    Bytes = track.Bytes,
                    UnitPrice = track.UnitPrice
                });
            }

            return results;
        }

        public List<AlbumDto> FindAlbumsByInterpret(string interpret)
        {
            var albums = _context.Artist
                .Include("Album")
                .First(artist => artist.Name.Equals(interpret, StringComparison.OrdinalIgnoreCase));

            return albums.Album.Select(album => new AlbumDto {Title = album.Title}).ToList();
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