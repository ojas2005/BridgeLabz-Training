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
    public sealed class VisitUtility : IVisitUtility
    {
        // CREATE
        public void RecordVisit(int appointmentId, string diagnosis, string? notes)
        {
            if (appointmentId <= 0) throw new ValidationException("AppointmentId must be > 0.");
            if (string.IsNullOrWhiteSpace(diagnosis)) throw new ValidationException("Diagnosis required.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPVisits_Record", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
                cmd.Parameters.AddWithValue("@diagnosis", diagnosis.Trim());
                DbUtil.AddNullable(cmd, "@notes", notes, SqlDbType.VarChar);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // UPDATE
        public void UpdateVisit(int visitId, string diagnosis, string? notes)
        {
            if (visitId <= 0) throw new ValidationException("VisitId must be > 0.");
            if (string.IsNullOrWhiteSpace(diagnosis)) throw new ValidationException("Diagnosis required.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPVisits_Update", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@visit_id", visitId);
                cmd.Parameters.AddWithValue("@diagnosis", diagnosis.Trim());
                DbUtil.AddNullable(cmd, "@notes", notes, SqlDbType.VarChar);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // DELETE
        public void DeleteVisit(int visitId)
        {
            if (visitId <= 0) throw new ValidationException("VisitId must be > 0.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPVisits_Delete", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@visit_id", visitId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // READ
        public List<string> MedicalHistoryLines(int patientId)
        {
            if (patientId <= 0) throw new ValidationException("PatientId must be > 0.");
            var lines = new List<string>();

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPVisits_MedicalHistory", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@patient_id", patientId);

                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var dt = r.GetDateTime(r.GetOrdinal("visit_date")).ToString("yyyy-MM-dd HH:mm");
                    var doc = r.GetString(r.GetOrdinal("doctor_name"));
                    var diag = r.GetString(r.GetOrdinal("diagnosis"));

                    var med = r.IsDBNull(r.GetOrdinal("medicine_name")) ? "-" : r.GetString(r.GetOrdinal("medicine_name"));
                    var dose = r.IsDBNull(r.GetOrdinal("dosage")) ? "-" : r.GetString(r.GetOrdinal("dosage"));

                    lines.Add($"{dt} | Dr.{doc} | {diag} | {med} ({dose})");
                }
            }
            catch (SqlException ex) { throw new DatabaseOperationException(ex.Message, ex); }

            return lines;
        }
    }
}
