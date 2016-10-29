using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 exists only to fix the javascript serialicer 
 no constructor has to be public .. sigh
     */
namespace bookstore.backend.Class
{
    public class Ibooks
    {
        public List<IBook> books { get; set;}

    }
}
