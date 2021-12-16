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
        public string Zipcode { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Rent { get; set; }
        public decimal Beds { get; set; }
        public decimal Baths { get; set; }
        public int Size { get; set; }
        public int OwnerId { get; set;}
        public int UserId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
