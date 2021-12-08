using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Apllicant
    {
        public int ApllicantId { get; set; }
        public string Name { get; set; }
        public string SocialHash { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool HasPets { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public int PropertyId { get; set; }
    }
}
