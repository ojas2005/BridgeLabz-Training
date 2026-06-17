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
    public sealed class AppointmentUtility : IAppointmentUtility
    {
        // CREATE
        public void Book(Appointment a)
        {
            if (a.PatientId <= 0 || a.DoctorId <= 0) throw new ValidationException("PatientId/DoctorId required.");
            if (a.AppointmentDate == default) throw new ValidationException("Date required.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPAppointments_Book", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@patient_id", a.PatientId);
                cmd.Parameters.AddWithValue("@doctor_id", a.DoctorId);
                cmd.Parameters.AddWithValue("@appointment_date", a.AppointmentDate.Date);
                cmd.Parameters.AddWithValue("@appointment_time", a.AppointmentTime);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // UPDATE
        public void Reschedule(int appointmentId, DateTime newDate, TimeSpan newTime, int? newDoctorId, string? reason, string? changedBy)
        {
            if (appointmentId <= 0) throw new ValidationException("AppointmentId must be > 0.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPAppointments_Reschedule", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
                cmd.Parameters.AddWithValue("@new_date", newDate.Date);
                cmd.Parameters.AddWithValue("@new_time", newTime);
                DbUtil.AddNullable(cmd, "@new_doctor_id", newDoctorId, SqlDbType.Int);
                DbUtil.AddNullable(cmd, "@reason", reason, SqlDbType.VarChar);
                DbUtil.AddNullable(cmd, "@changed_by", changedBy, SqlDbType.VarChar);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // DELETE
        public void Cancel(int appointmentId, string? reason, string? changedBy)
        {
            if (appointmentId <= 0) throw new ValidationException("AppointmentId must be > 0.");

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPAppointments_Cancel", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
                DbUtil.AddNullable(cmd, "@reason", reason, SqlDbType.VarChar);
                DbUtil.AddNullable(cmd, "@changed_by", changedBy, SqlDbType.VarChar);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) { throw new BusinessRuleException(ex.Message); }
        }

        // READ
        public List<string> DailyScheduleLines(DateTime date)
        {
            var lines = new List<string>();

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPAppointments_DailySchedule", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@date", date.Date);

                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var time = r.GetTimeSpan(r.GetOrdinal("appointment_time")).ToString(@"hh\:mm");
                    var patient = r.GetString(r.GetOrdinal("full_name"));
                    var doc = r.GetString(r.GetOrdinal("doctor_name"));
                    var st = r.GetString(r.GetOrdinal("status"));

                    lines.Add($"{time} | {patient} | Dr.{doc} | {st}");
                }
            }
            catch (SqlException ex) { throw new DatabaseOperationException(ex.Message, ex); }

            return lines;
        }

        public List<string> DoctorAvailabilityLines(int doctorId, DateTime date)
        {
            if (doctorId <= 0) throw new ValidationException("DoctorId must be > 0.");
            var lines = new List<string>();

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPAppointments_CheckAvailability", con) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@doctor_id", doctorId);
                cmd.Parameters.AddWithValue("@appointment_date", date.Date);

                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var time = r.GetTimeSpan(r.GetOrdinal("appointment_time")).ToString(@"hh\:mm");
                    var count = r.GetInt32(r.GetOrdinal("booked_count"));
                    lines.Add($"{time} -> booked: {count}");
                }
            }
            catch (SqlException ex) { throw new DatabaseOperationException(ex.Message, ex); }

            return lines;
        }
    }
}
