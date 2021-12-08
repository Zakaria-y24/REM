using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class ApplicantDAO : IApplicantDAO
    {
        private string connectionString;

        public ApplicantDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Applicant AddApplicant(int userId, Applicant itemTOAdd)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                const string sql = "INSERT INTO applicants(applicant_name, applicant_social, applicant_birthDate, applicant_email, applicant_address, applicant_hasPets, applicant_salary, applicant_phone, applicant_property, applicant_user_id) VALUES(@name, @social, @birthdate, @email, @address, @hasPets, @salary, @phoneNumber, @propertyId, @user_id); SELECT @@IDENTITY;";

                


                using (SqlCommand command = new SqlCommand(sql, conn))
                {


                    command.Parameters.AddWithValue("@name", itemTOAdd.Name);
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.Parameters.AddWithValue("@social", itemTOAdd.Social);
                    command.Parameters.AddWithValue("@birthdate", itemTOAdd.BirthDate);
                    command.Parameters.AddWithValue("@email", itemTOAdd.Email);
                    command.Parameters.AddWithValue("@address", itemTOAdd.Address);
                    command.Parameters.AddWithValue("@hasPets", itemTOAdd.HasPets);
                    command.Parameters.AddWithValue("@salary", itemTOAdd.Salary);
                    command.Parameters.AddWithValue("@phoneNumber", itemTOAdd.PhoneNumber);
                    command.Parameters.AddWithValue("@propertyId", itemTOAdd.PropertyId);

                    int newRowId = Convert.ToInt32(command.ExecuteScalar());
                    itemTOAdd.ApllicantId = newRowId;

                }

            }
            return itemTOAdd;

        }
        public IEnumerable<Applicant> GetAllApplicants(int userId)
        {
            List<Applicant> applicants = new List<Applicant>();

            const string SELECT = "SELECT applicant_id, applicant_name, applicant_social, applicant_birthDate, applicant_email, applicant_address, applicant_hasPets, applicant_salary, applicant_phone, applicant_property FROM applicants WHERE applicant_user_id = @user_id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(SELECT, conn);
                command.Parameters.AddWithValue("@user_id", userId);

                using (SqlCommand cmd = new SqlCommand(SELECT, conn))
                {
                   

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Applicant applicant = new Applicant();

                            applicant.ApllicantId = Convert.ToInt32(reader["applicant_id"]);
                            applicant.Name = Convert.ToString(reader["applicant_name"]);
                            applicant.Social = Convert.ToInt32(reader["applicant_social"]);
                            applicant.BirthDate = Convert.ToDateTime(reader["applicant_birthDate"]);
                            applicant.Email = Convert.ToString(reader["applicant_email"]);
                            applicant.Address = Convert.ToString(reader["applicant_address"]);
                            applicant.HasPets = Convert.ToBoolean(reader["applicant_hasPets"]);
                            applicant.Salary = Convert.ToInt32(reader["applicant_salary"]);
                            applicant.PhoneNumber = Convert.ToString(reader["applicant_phone"]);
                            applicant.PropertyId = Convert.ToInt32(reader["applicant_property"]);
                            applicants.Add(applicant);
                        }
                    }
                }
            }

            return applicants;
        }
    }
}
