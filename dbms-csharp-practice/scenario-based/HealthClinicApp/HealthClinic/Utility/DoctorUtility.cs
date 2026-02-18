using HealthClinic.Connection;
using HealthClinic.Exception;
using HealthClinic.Interfaces;
using HealthClinic.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HealthClinic.Utility
{
    public sealed class DoctorUtility : IDoctorUtility
    {
        // CREATE
        public void AddDoctor(Doctor d)
        {
            Validate(d, requireId: false);

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPDoctors_Insert", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@doctor_name", d.DoctorName);
                DbUtil.AddNullable(cmd, "@contact", d.Contact, SqlDbType.VarChar);
                cmd.Parameters.AddWithValue("@consultation_fee", d.ConsultationFee);
                cmd.Parameters.AddWithValue("@specialty_id", d.SpecialtyId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // UPDATE
        public void UpdateDoctor(Doctor d)
        {
            Validate(d, requireId: true);

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPDoctors_Update", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@doctor_id", d.DoctorId);
                cmd.Parameters.AddWithValue("@doctor_name", d.DoctorName);
                DbUtil.AddNullable(cmd, "@contact", d.Contact, SqlDbType.VarChar);
                cmd.Parameters.AddWithValue("@consultation_fee", d.ConsultationFee);
                cmd.Parameters.AddWithValue("@specialty_id", d.SpecialtyId);
                cmd.Parameters.AddWithValue("@is_active", d.IsActive);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        public void UpdateDoctorSpecialty(int doctorId, int specialtyId)
        {
            if (doctorId <= 0 || specialtyId <= 0) throw new ValidationException("Ids must be > 0.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPDoctors_UpdateSpecialty", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@doctor_id", doctorId);
                cmd.Parameters.AddWithValue("@specialty_id", specialtyId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // DELETE
        public void DeactivateDoctor(int doctorId)
        {
            if (doctorId <= 0) throw new ValidationException("DoctorId must be > 0.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPDoctors_Deactivate", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@doctor_id", doctorId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // READ
        public List<Doctor> GetDoctorsBySpecialty(string specialtyName)
        {
            if (string.IsNullOrWhiteSpace(specialtyName)) throw new ValidationException("Specialty name required.");
            var list = new List<Doctor>();

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPDoctors_BySpecialty", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@specialty_name", specialtyName.Trim());

                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    list.Add(new Doctor
                    {
                        DoctorName = r.GetString(r.GetOrdinal("doctor_name")),
                        ConsultationFee = r.GetDecimal(r.GetOrdinal("consultation_fee")),
                        Contact = r.IsDBNull(r.GetOrdinal("contact")) ? null : r.GetString(r.GetOrdinal("contact"))
                    });
                }
            }
            catch (SqlException ex) { throw new DatabaseOperationException(ex.Message, ex); }

            return list;
        }

        // HELPER VALIDATION
        private static void Validate(Doctor d, bool requireId)
        {
            if (requireId && d.DoctorId <= 0) throw new ValidationException("DoctorId must be > 0.");
            if (string.IsNullOrWhiteSpace(d.DoctorName)) throw new ValidationException("DoctorName required.");
            if (d.SpecialtyId <= 0) throw new ValidationException("SpecialtyId required.");
            if (d.ConsultationFee <= 0) throw new ValidationException("ConsultationFee must be > 0.");
        }
    }
}
