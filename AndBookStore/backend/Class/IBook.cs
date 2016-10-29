using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 exists only to fix the javascript serializer , may be removed in refactorting sweap,
 but just make work at all costs is where we are at.      
     */
namespace bookstore.backend.Class
{
    public class IBook
    {
        public string title { get; set; }
        public string author { get; set; }
        public decimal price { get; set; }     
        public int inStock { get; set; }
    }
}