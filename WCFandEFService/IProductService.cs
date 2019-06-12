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

        //[OperationContract]
        List<Track> FindTracksByTitle(string title);

        //[OperationContract]
        List<Album> FindAlbumsByInterpret(string interpret);

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
}
