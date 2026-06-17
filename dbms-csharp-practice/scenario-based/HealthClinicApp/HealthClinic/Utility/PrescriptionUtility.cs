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
    public sealed class PrescriptionUtility : IPrescriptionUtility
    {
        // CREATE
        public void AddPrescription(int visitId, string medicine, string dosage, int durationDays, string? instructions)
        {
            if (visitId <= 0) throw new ValidationException("VisitId must be > 0.");
            if (string.IsNullOrWhiteSpace(medicine)) throw new ValidationException("Medicine required.");
            if (string.IsNullOrWhiteSpace(dosage)) throw new ValidationException("Dosage required.");
            if (durationDays <= 0) throw new ValidationException("DurationDays must be > 0.");

            Exec("clinic.SPPrescriptions_Insert", cmd =>
            {
                cmd.Parameters.AddWithValue("@visit_id", visitId);
                cmd.Parameters.AddWithValue("@medicine_name", medicine.Trim());
                cmd.Parameters.AddWithValue("@dosage", dosage.Trim());
                cmd.Parameters.AddWithValue("@duration_days", durationDays);
                DbUtil.AddNullable(cmd, "@instructions", instructions, SqlDbType.VarChar);
            });
        }

        // UPDATE
        public void UpdatePrescription(int prescriptionId, string medicine, string dosage, int durationDays, string? instructions)
        {
            if (prescriptionId <= 0) throw new ValidationException("PrescriptionId must be > 0.");

            Exec("clinic.SPPrescriptions_Update", cmd =>
            {
                cmd.Parameters.AddWithValue("@prescription_id", prescriptionId);
                cmd.Parameters.AddWithValue("@medicine_name", medicine.Trim());
                cmd.Parameters.AddWithValue("@dosage", dosage.Trim());
                cmd.Parameters.AddWithValue("@duration_days", durationDays);
                DbUtil.AddNullable(cmd, "@instructions", instructions, SqlDbType.VarChar);
            });
        }

        // DELETE
        public void DeletePrescription(int prescriptionId)
        {
            if (prescriptionId <= 0) throw new ValidationException("PrescriptionId must be > 0.");

            Exec("clinic.SPPrescriptions_Delete", cmd =>
            {
                cmd.Parameters.AddWithValue("@prescription_id", prescriptionId);
            });
        }

        // HELPER DB EXECUTION
        private static void Exec(string spName, Action<SqlCommand> fill)
        {
            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand(spName, con) { CommandType = CommandType.StoredProcedure };

                fill(cmd);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }
    }
}
