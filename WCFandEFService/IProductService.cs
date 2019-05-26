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

        /*[OperationContract]
        void DeleteAlbum(int id);

        [OperationContract]
        List<Album> FindAlbumsByTitle(String title);

        [OperationContract]
        List<Track> FindTracksByTitle(String title);

        [OperationContract]
        List<Album> FindAlbumsByInterpret(String interpret);

        [OperationContract]
        List<Track> FindBoughtTracksByClient(String client);

        [OperationContract]
        List<Invoice> FindInvoicesByClient(String client);*/
    }

    /*[DataContract]
    public class Product
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string QuantityPerUnit { get; set; }
        [DataMember]
        public decimal UnitPrice { get; set; }
        [DataMember]
        public bool Discontinued { get; set; }
    }*/
}
