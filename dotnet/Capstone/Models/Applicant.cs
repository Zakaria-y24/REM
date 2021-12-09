using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Applicant
    {
        public int ApllicantId { get; set; }
        public string Name { get; set; }
        public int Social { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date;
        public DateTime BirthDate { get; set; }
        public string Status { get; set; } = "Pending";
        public string Email { get; set; }
        public string Address { get; set; }
        public bool HasPets { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public int PropertyId { get; set; }

    }
}
