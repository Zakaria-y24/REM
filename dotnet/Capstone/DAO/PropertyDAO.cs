using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class PropertyDAO : IPropertyDAO
    {
        private string connectionString;

        public PropertyDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Property> GetAllProperties()
        {
            List<Property> properties = new List<Property>();

            const string SELECT = "SELECT property_id, property_address, property_name, property_beds, property_baths, property_size, property_owner FROM properties";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(SELECT, conn))
                {
                    // Set parameters for my SQL here

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Property property = new Property();

                            property.Id = Convert.ToInt32(reader["property_id"]);
                            property.Address = Convert.ToString(reader["property_address"]);
                            property.Name = Convert.ToString(reader["property_name"]);
                            property.Beds = Convert.ToInt32(reader["property_beds"]);
                            property.Baths = Convert.ToInt32(reader["property_baths"]);
                            property.Size = Convert.ToInt32(reader["property_size"]);
                            property.OwnerId = Convert.ToInt32(reader["property_owner"]);
                            properties.Add(property);
                        }
                    }
                }
            }

            return properties;
        }
    }
}
