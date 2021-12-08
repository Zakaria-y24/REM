using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Name { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public int Size { get; set; }
        public int OwnerId { get; set;}
        public int UserId { get; set; }
        public bool IsAvailable { get; set; }


    }
}
