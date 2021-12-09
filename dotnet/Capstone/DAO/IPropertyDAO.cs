using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPropertyDAO
    {
        IEnumerable<Property> GetAllProperties();
        Property AddProperty(int userId, Property itemTOAdd);
        IEnumerable<Property> SearchProperties(string zipcode, string beds, string baths);
    }
}