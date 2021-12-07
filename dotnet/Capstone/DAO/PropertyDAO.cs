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
        private static List<Property> Properties { get; set; }
        public PropertyDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Property> GetAllProperties()
        {
            List<Property> properties = new List<Property>();

            const string SELECT = "SELECT property_id, property_address, property_name, property_beds, property_baths, property_size, property_owner, is_available FROM properties";

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
                            property.IsAvailable = Convert.ToBoolean(reader["is_available"]);
                            properties.Add(property);
                        }
                    }
                }
            }

            return properties;
        }

        public Property AddProperty(int userId, Property itemTOAdd)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                const string sql = "INSERT INTO properties (property_address, property_name, property_beds,property_baths, property_size,property_owner) " +
                    "VALUES(@address,@name, @beds, @baths,@size,@ownerId); SELECT @@IDENTITY;";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@address", itemTOAdd.Address);
                    command.Parameters.AddWithValue("@ownerId", userId);
                    command.Parameters.AddWithValue("@beds", itemTOAdd.Beds);
                    command.Parameters.AddWithValue("@baths", itemTOAdd.Baths);
                    command.Parameters.AddWithValue("@name", itemTOAdd.Name);
                    command.Parameters.AddWithValue("@size", itemTOAdd.Size);

                    int newRowId = Convert.ToInt32(command.ExecuteScalar());
                    itemTOAdd.Id = newRowId;

                }

            }
            return itemTOAdd;

        }
    }
}
