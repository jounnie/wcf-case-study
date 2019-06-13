using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
            _context.Database.Log = sql => Debug.Write(sql);
        }

        public void AddAlbumWithTracks()
        {
            Artist newArtist = new Artist();
            newArtist.Name = "Rammstein";
            
            Album newAlbum = new Album();
            newAlbum.Title = "RAMMSTEIN";
            newAlbum.Artist = newArtist;
            
            Track t1 = new Track();
            t1.Album = newAlbum;
            t1.Name = "DEUTSCHLAND";
            t1.MediaTypeId = 1;
            t1.Milliseconds = 42;
            t1.UnitPrice = new decimal(5.5);

            var persisted = _context.Track.Add(t1);
            _context.SaveChanges();
            Console.WriteLine(persisted);
        }

        public int DeleteAlbum(int id)
        {
            var album = _context.Album.Find(id);

            if (album == null)
            {
                return 0;
            }

            _context.Album.Remove(album);
            return _context.SaveChanges();
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
                results.Add(TransformTo(track));
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

        public List<TrackDto> FindBoughtTracksByClient(string client)
        {
            DbSet<Track> contextTrack = _context.Track;
            DbSet<InvoiceLine> contextInvoiceLine = _context.InvoiceLine;
            DbSet<Invoice> contextInvoice = _context.Invoice;
            DbSet<Customer> contextCustomer = _context.Customer;

            var query =
                from track in contextTrack
                join invoiceLine in contextInvoiceLine
                    on track.TrackId equals invoiceLine.TrackId
                join invoice in contextInvoice
                    on invoiceLine.InvoiceId equals invoice.InvoiceId
                join customer in contextCustomer
                    on invoice.CustomerId equals customer.CustomerId
                where customer.LastName == client
                select track;

            var results = new List<TrackDto>();
            foreach (var track in query)
            {
                results.Add(TransformTo(track));
            }

            return results;
        }

        public List<InvoiceDto> FindInvoicesByClient(string client)
        {
            DbSet<Invoice> contextInvoice = _context.Invoice;
            DbSet<Customer> contextCustomer = _context.Customer;

            var query =
                from invoice in contextInvoice
                join customer in contextCustomer
                    on invoice.CustomerId equals customer.CustomerId
                where customer.LastName == client
                select invoice;

            var results = new List<InvoiceDto>();
            foreach (var invoice in query)
            {
                results.Add(new InvoiceDto
                {
                    InvoiceId = invoice.InvoiceId,
                    CustomerId = invoice.CustomerId,
                    InvoiceDate = invoice.InvoiceDate,
                    BillingAddress = invoice.BillingAddress,
                    BillingCity = invoice.BillingCity,
                    BillingState = invoice.BillingState,
                    BillingCountry = invoice.BillingCountry,
                    BillingPostalCode = invoice.BillingPostalCode,
                    Total = invoice.Total
                });
            }

            return results;
        }

        private static TrackDto TransformTo(Track track)
        {
            return new TrackDto
            {
                TrackId = track.TrackId,
                Name = track.Name,
                AlbumId = track.AlbumId,
                MediaTypeId = track.MediaTypeId,
                GenreId = track.GenreId,
                Composer = track.Composer,
                Milliseconds = track.Milliseconds,
                Bytes = track.Bytes,
                UnitPrice = track.UnitPrice
            };
        }
    }
}