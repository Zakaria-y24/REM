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

            const string SELECT = "SELECT property_id, property_street, property_city, property_state, property_zipcode, property_type, property_description, property_name, property_beds, property_baths, property_size, property_owner, property_isAvailable FROM properties";

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
                            property.Street = Convert.ToString(reader["property_street"]);
                            property.City = Convert.ToString(reader["property_city"]);
                            property.State = Convert.ToString(reader["property_state"]);
                            property.Zipcode = Convert.ToString(reader["property_zipcode"]);
                            property.Type = Convert.ToString(reader["property_type"]);
                            property.Description = Convert.ToString(reader["property_description"]);
                            property.Name = Convert.ToString(reader["property_name"]);
                            property.Beds = Convert.ToInt32(reader["property_beds"]);
                            property.Baths = Convert.ToInt32(reader["property_baths"]);
                            property.Size = Convert.ToInt32(reader["property_size"]);
                            property.OwnerId = Convert.ToInt32(reader["property_owner"]);
                            property.IsAvailable = Convert.ToBoolean(reader["property_isAvailable"]);
                            properties.Add(property);
                        }
                    }
                }
            }

            return properties;
        }
        public IEnumerable<Property> GetAllMyProperties(int userId)
        {
            List<Property> properties = new List<Property>();

            const string SELECT = "SELECT property_id, property_street, property_city, property_state, property_zipcode, property_type, property_description, property_name, property_beds, property_baths, property_size, property_owner, property_isAvailable FROM properties WHERE property_owner = @user_id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(SELECT, conn);
                command.Parameters.AddWithValue("@user_id", userId);



                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Property property = new Property();

                        property.Id = Convert.ToInt32(reader["property_id"]);
                        property.Street = Convert.ToString(reader["property_street"]);
                        property.City = Convert.ToString(reader["property_city"]);
                        property.State = Convert.ToString(reader["property_state"]);
                        property.Zipcode = Convert.ToString(reader["property_zipcode"]);
                        property.Type = Convert.ToString(reader["property_type"]);
                        property.Description = Convert.ToString(reader["property_description"]);
                        property.Name = Convert.ToString(reader["property_name"]);
                        property.Beds = Convert.ToInt32(reader["property_beds"]);
                        property.Baths = Convert.ToInt32(reader["property_baths"]);
                        property.Size = Convert.ToInt32(reader["property_size"]);
                        property.OwnerId = Convert.ToInt32(reader["property_owner"]);
                        property.IsAvailable = Convert.ToBoolean(reader["property_isAvailable"]);
                        properties.Add(property);
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
                const string sql = "INSERT INTO properties (property_street,property_city,property_state,property_zipcode,property_type,property_description, property_name, property_beds, property_baths, property_size, property_owner, property_isAvailable) " +
                    "VALUES(@street, @city, @state, @zipcode,@type, @description, @name, @beds, @baths,@size,@ownerId, @IsAvailable); SELECT @@IDENTITY;";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@street", itemTOAdd.Street);
                    command.Parameters.AddWithValue("@ownerId", userId);
                    command.Parameters.AddWithValue("@state", itemTOAdd.State);
                    command.Parameters.AddWithValue("@city", itemTOAdd.City);
                    command.Parameters.AddWithValue("@zipcode", itemTOAdd.Zipcode);
                    command.Parameters.AddWithValue("@type", itemTOAdd.City);
                    command.Parameters.AddWithValue("@description", itemTOAdd.Description);
                    command.Parameters.AddWithValue("@beds", itemTOAdd.Beds);
                    command.Parameters.AddWithValue("@baths", itemTOAdd.Baths);
                    command.Parameters.AddWithValue("@name", itemTOAdd.Name);
                    command.Parameters.AddWithValue("@size", itemTOAdd.Size);
                    command.Parameters.AddWithValue("@IsAvailable", itemTOAdd.IsAvailable);

                    int newRowId = Convert.ToInt32(command.ExecuteScalar());
                    itemTOAdd.Id = newRowId;

                }

            }
            return itemTOAdd;

        }
        public IEnumerable<Property> SearchProperties(string zipcode, string beds, string baths)
        {
            List<Property> properties = new List<Property>();

            const string SELECT = "SELECT property_id, property_street, property_city, " +
                "property_state, property_zipcode, property_name, " +
                "property_beds, property_baths, property_size, property_owner, property_isAvailable FROM properties " +
                "WHERE property_zipcode = @zipcode AND property_beds >= @beds AND property_baths >= @baths";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(SELECT, conn))
                {
                    command.Parameters.AddWithValue("@zipcode", zipcode);
                    command.Parameters.AddWithValue("@beds", beds);
                    command.Parameters.AddWithValue("@baths", baths);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Property property = new Property();

                            property.Id = Convert.ToInt32(reader["property_id"]);
                            property.Street = Convert.ToString(reader["property_street"]);
                            property.City = Convert.ToString(reader["property_city"]);
                            property.State = Convert.ToString(reader["property_state"]);
                            property.Zipcode = Convert.ToString(reader["property_zipcode"]);
                            property.Name = Convert.ToString(reader["property_name"]);
                            property.Beds = Convert.ToInt32(reader["property_beds"]);
                            property.Baths = Convert.ToInt32(reader["property_baths"]);
                            property.Size = Convert.ToInt32(reader["property_size"]);
                            property.OwnerId = Convert.ToInt32(reader["property_owner"]);
                            property.IsAvailable = Convert.ToBoolean(reader["property_isAvailable"]);
                            properties.Add(property);
                        }
                    }
                }
            }

            return properties;
        }
    }
}
