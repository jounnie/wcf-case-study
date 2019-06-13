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

        [OperationContract]
        int DeleteAlbum(int id);

        [OperationContract]
        List<AlbumDto> FindAlbumsByTitle(string title);

        [OperationContract]
        List<TrackDto> FindTracksByTitle(string title);

        [OperationContract]
        List<AlbumDto> FindAlbumsByInterpret(string interpret);

        [OperationContract]
        List<TrackDto> FindBoughtTracksByClient(string client);

        [OperationContract]
        List<InvoiceDto> FindInvoicesByClient(string client);
    }

    [DataContract]
    public class AlbumDto
    {
        [DataMember] public string Title { get; set; }

        public override string ToString() => $"{nameof(Title)}: {Title}";
    }

    [DataContract]
    public class TrackDto
    {
        [DataMember] public int TrackId { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public int? AlbumId { get; set; }
        [DataMember] public int MediaTypeId { get; set; }
        [DataMember] public int? GenreId { get; set; }
        [DataMember] public string Composer { get; set; }
        [DataMember] public int Milliseconds { get; set; }
        [DataMember] public int? Bytes { get; set; }
        [DataMember] public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(TrackId)}: {TrackId}, {nameof(Name)}: {Name}, {nameof(AlbumId)}: {AlbumId}, {nameof(MediaTypeId)}: {MediaTypeId}, {nameof(GenreId)}: {GenreId}, {nameof(Composer)}: {Composer}, {nameof(Milliseconds)}: {Milliseconds}, {nameof(Bytes)}: {Bytes}, {nameof(UnitPrice)}: {UnitPrice}";
        }
    }

    [DataContract]
    public class InvoiceDto
    {
        [DataMember] public int InvoiceId { get; set; }
        [DataMember] public int CustomerId { get; set; }
        [DataMember] public System.DateTime InvoiceDate { get; set; }
        [DataMember] public string BillingAddress { get; set; }
        [DataMember] public string BillingCity { get; set; }
        [DataMember] public string BillingState { get; set; }
        [DataMember] public string BillingCountry { get; set; }
        [DataMember] public string BillingPostalCode { get; set; }
        [DataMember] public decimal Total { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(InvoiceId)}: {InvoiceId}, {nameof(CustomerId)}: {CustomerId}, {nameof(InvoiceDate)}: {InvoiceDate}, {nameof(BillingAddress)}: {BillingAddress}, {nameof(BillingCity)}: {BillingCity}, {nameof(BillingState)}: {BillingState}, {nameof(BillingCountry)}: {BillingCountry}, {nameof(BillingPostalCode)}: {BillingPostalCode}, {nameof(Total)}: {Total}";
        }
    }
}