using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSqlServer
{
   class Program
   {
      static void Main(string[] args)
      { 
        
         var db = new ChinookEntities();

         IEnumerable<Album> albumsQuery =
            from album in db.Album.AsEnumerable()
            select album;

         IEnumerable<Album> albumsArray = albumsQuery.ToArray();

         foreach (Album album in albumsArray)
         {
            Console.WriteLine(album.Title);
         }
      }
   }
}
