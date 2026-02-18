using HealthClinic.Connection;
using HealthClinic.Exception;
using HealthClinic.Interfaces;
using HealthClinic.Models;
using Microsoft.Data.SqlClient;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace HealthClinic.Utility
{
    public sealed class PatientUtility : IPatients
    {
        // CREATE
        public void AddPatients(Patients patient)
        {
            ValidatePatients(patient, requiredID: false);

            try
            {
                using var connection = DB_Connection.CreateConnection();
                using var commands = new SqlCommand("clinic.SPPatients_Insert", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                commands.Parameters.AddWithValue("@full_name", patient.full_name);
                commands.Parameters.AddWithValue("@dob", patient.dob);
                commands.Parameters.AddWithValue("@phone", patient.phone);
                commands.Parameters.AddWithValue("@email", (object?) patient.email ?? DBNull.Value);
                commands.Parameters.AddWithValue("@address", (object?)patient.address ?? DBNull.Value);
                commands.Parameters.AddWithValue("@blood_group", (object?)patient.blood_group ?? DBNull.Value);

                connection.Open();
                commands.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new DatabaseOperationException(ex.Message, ex);
            }
        }

        // UPDATE
        public void UpdatePatients(Patients patient)
        {
            ValidatePatients(patient, requiredID: true);

            try
            {
                using var connection = DB_Connection.CreateConnection();
                using var commands = new SqlCommand("clinic.SPPatients_Update", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                commands.Parameters.AddWithValue("@patient_id", patient.patient_id);
                commands.Parameters.AddWithValue("@full_name", patient.full_name);
                commands.Parameters.AddWithValue("@dob", patient.dob);
                commands.Parameters.AddWithValue("@phone", patient.phone);
                commands.Parameters.AddWithValue("@email", (object?)patient.email ?? DBNull.Value);
                commands.Parameters.AddWithValue("@address", (object?)patient.address ?? DBNull.Value);
                commands.Parameters.AddWithValue("@blood_group", (object?)patient.blood_group ?? DBNull.Value);

                connection.Open();
                commands.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new DatabaseOperationException(ex.Message, ex);
            }
        }

        // DELETE
        public void DeletePatients(int patient_id)
        {
            if (patient_id <= 0) throw new ValidationException("Patient Id should be more than zero");

            try
            {
                using var connection = DB_Connection.CreateConnection();
                using var commands = new SqlCommand("clinic.SPPatients_Delete", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                commands.Parameters.AddWithValue("@patient_id", patient_id);

                connection.Open();
                var rows = commands.ExecuteNonQuery();
                if (rows == 0) throw new NotFoundException("Patient not found");
            }
            catch(SqlException ex)
            {
                throw new DatabaseOperationException(ex.Message, ex);
            }
        }

        // READ SEARCH
        public List<Patients> SearchPatients(string keyword)
        {
            if(string.IsNullOrWhiteSpace(keyword)) throw new ValidationException("Search keyword cannot be Empty");
            var list = new List<Patients>();
            try
            {
                using var connection = DB_Connection.CreateConnection();
                using var commands = new SqlCommand("clinic.SPPatients_Search", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                commands.Parameters.AddWithValue("@keyword", keyword.Trim());
                connection.Open();
                using var reader = commands.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Patients {
                        patient_id =reader.GetInt32(reader.GetOrdinal("patient_id"))
                        ,full_name =reader.GetString(reader.GetOrdinal("full_name"))
                        ,dob = reader.GetDateTime(reader.GetOrdinal("dob"))
                        ,phone = reader.GetString(reader.GetOrdinal("phone"))
                        ,email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString(reader.GetOrdinal("email"))
                        ,address = reader.IsDBNull(reader.GetOrdinal("address"))? null: reader.GetString(reader.GetOrdinal("address"))
                        ,blood_group = reader.IsDBNull(reader.GetOrdinal("blood_group"))?null:reader.GetString(reader.GetOrdinal("blood_group"))
                    });
                }
            }
            catch(SqlException ex)
            {
                throw new DatabaseOperationException(ex.Message, ex);
            }
            return list;
        }

        // READ HISTORY
        public List<String> GetVisitHistory(int patient_id)
        {
            if (patient_id <= 0) throw new ValidationException("patient Id must be above zero");
            var list = new List<string>();
            try
            {
                using var connection = DB_Connection.CreateConnection();
                using var commands = new SqlCommand("clinic.SPPatients_Visithistory", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                commands.Parameters.AddWithValue("@patient_id", patient_id);
                connection.Open();

                using var reader = commands.ExecuteReader();
                while (reader.Read())
                {
                    var date = reader.GetDateTime(reader.GetOrdinal("appointment_date")).ToString("yyyy-MM-dd");
                    var time = reader.GetTimeSpan(reader.GetOrdinal("appointment_time")).ToString(@"hh\:mm");
                    var doc = reader.GetString(reader.GetOrdinal("doctor_name"));
                    var diagnosis = reader.IsDBNull(reader.GetOrdinal("diagnosis")) ? "-" : reader.GetString(reader.GetOrdinal("diagnosis"));

                    list.Add("Date: " + date + " Time: " + time + " Dr. " + doc + " Diagnosis: " + diagnosis);
                }
            }
            catch(SqlException ex)
            {
                throw new DatabaseOperationException(ex.Message, ex);
            }
            return list;    
        }

        // HELPER VALIDATION
        private static void ValidatePatients(Patients p, bool requiredID)
        {
            if (requiredID && p.patient_id <= 0) throw new ValidationException("Patient ID Must be over 0");
            if (string.IsNullOrWhiteSpace(p.full_name)) throw new ValidationException("FullName of the Patient is required");
            if (p.dob == default) throw new ValidationException("DOB is required");
            if (string.IsNullOrWhiteSpace(p.phone)) throw new ValidationException("Phone number is required");
        }
    }
}
