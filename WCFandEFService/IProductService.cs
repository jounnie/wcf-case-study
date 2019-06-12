using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DemoSqlServer;

namespace WCFandEFService
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        void AddAlbumWithTracks();

        //[OperationContract]
        void DeleteAlbum(int id);

        [OperationContract]
        List<AlbumDto> FindAlbumsByTitle(string title);

        [OperationContract]
        List<TrackDto> FindTracksByTitle(string title);

        [OperationContract]
        List<AlbumDto> FindAlbumsByInterpret(string interpret);

        //[OperationContract]
        List<Track> FindBoughtTracksByClient(string client);

        //[OperationContract]
        List<Invoice> FindInvoicesByClient(string client);
    }

    [DataContract]
    public class AlbumDto
    {
        [DataMember]
        public string Title { get; set; }

        public override string ToString() => $"{nameof(Title)}: {Title}";
    }
    
    [DataContract]
    public class TrackDto
    {
        [DataMember]
        public int TrackId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? AlbumId { get; set; }
        [DataMember]
        public int MediaTypeId { get; set; }
        [DataMember]
        public int? GenreId { get; set; }
        [DataMember]
        public string Composer { get; set; }
        [DataMember]
        public int Milliseconds { get; set; }
        [DataMember]
        public int? Bytes { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return $"{nameof(TrackId)}: {TrackId}, {nameof(Name)}: {Name}, {nameof(AlbumId)}: {AlbumId}, {nameof(MediaTypeId)}: {MediaTypeId}, {nameof(GenreId)}: {GenreId}, {nameof(Composer)}: {Composer}, {nameof(Milliseconds)}: {Milliseconds}, {nameof(Bytes)}: {Bytes}, {nameof(UnitPrice)}: {UnitPrice}";
        }
    }
}
