using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IPropertyDAO
    {
        IEnumerable<Property> GetAllProperties();
        Property AddProperty(int userId, Property itemTOAdd);
    }
}