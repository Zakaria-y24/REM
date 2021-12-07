using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public int Size { get; set; }
        public int OwnerId { get; set;}


    }
}
