using HealthClinic.Connection;
using HealthClinic.Exception;
using HealthClinic.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HealthClinic.Utility
{
    public sealed class SpecialtyUtility : ISpecialtyUtility
    {
        // CREATE
        public void AddSpecialty(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ValidationException("Specialty name required.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPSpecialties_Insert", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@specialty_name", name.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // UPDATE
        public void UpdateSpecialty(int id, string name, bool isActive)
        {
            if (id <= 0) throw new ValidationException("SpecialtyId must be > 0.");
            if (string.IsNullOrWhiteSpace(name)) throw new ValidationException("Specialty name required.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPSpecialties_Update", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@specialty_id", id);
                cmd.Parameters.AddWithValue("@specialty_name", name.Trim());
                cmd.Parameters.AddWithValue("@is_active", isActive);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // DELETE
        public void DeleteSpecialty(int id)
        {
            if (id <= 0) throw new ValidationException("SpecialtyId must be > 0.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPSpecialties_Delete", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@specialty_id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }
    }
}
