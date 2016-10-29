using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace bookstore.backend.Class
{
    public class DecodeJson
    {

        public static Ibooks decodejason(string json)
        {
             return JsonConvert.DeserializeObject<backend.Class.Ibooks>(json);
        }
        /*
        public static Ibooks decodejason(string json)// for testing async not working in nunit
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Ibooks books = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<backend.Class.Ibooks>(json);
            return books;

            // note a list is a enumrable just run command books.books.AsEnumerable();
        }
        */

        public static string downloadjson()// for testing async not working in nunit
        {
            Uri bookstore = new Uri("http://www.contribe.se/arbetsprov-net/books.json");
            var json = new WebClient().DownloadString(bookstore);
            return json;
        }
        /// <summary>
        /// not a hundred put think this is redundat and input and output is almost the same
        /// just the problem with not being allowed a constructor in decodejason backend.Class.Ibooks
        /// converts backend.Class.Ibooks to List<IBooksWithInterface>.asEnumerable since it was asked for..
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static IEnumerable<backend.Class.IBooksWithInterface> convert(Ibooks book)
        {// quick convertion fix .. there is probably a faster one...
            //IEnumerable<backend.Class.IBooksWithInterface> result;

            List<IBooksWithInterface> templist = new List<IBooksWithInterface>();
           
            foreach (var bok in book.books)// aa public to private variables... load ones.. 
            {
                templist.Add(new IBooksWithInterface(bok.title, bok.author, bok.price, bok.inStock));
            }
           // result = templist.AsEnumerable();
            return templist.AsEnumerable();
        }
    }
}