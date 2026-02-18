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
    public sealed class AuditUtility : IAuditUtility
    {
        // READ
        public List<string> ViewAuditLines(int top = 50)
        {
            if (top <= 0) top = 50;
            var lines = new List<string>();

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPAudit_View", con) { CommandType = CommandType.StoredProcedure };

                con.Open();
                using var r = cmd.ExecuteReader();

                int count = 0;
                while (r.Read() && count < top)
                {
                    // audit_log columns: audit_id, table_name, action_type, record_pk, changed_at, changed_by, old_data, new_data
                    var table = r.GetString(r.GetOrdinal("table_name"));
                    var action = r.GetString(r.GetOrdinal("action_type"));
                    var pk = r.GetString(r.GetOrdinal("record_pk"));
                    var at = r.GetDateTime(r.GetOrdinal("changed_at")).ToString("yyyy-MM-dd HH:mm");
                    var by = r.IsDBNull(r.GetOrdinal("changed_by")) ? "-" : r.GetString(r.GetOrdinal("changed_by"));

                    lines.Add($"{at} | {table} | {action} | PK={pk} | By={by}");
                    count++;
                }
            }
            catch (SqlException ex) { throw new DatabaseOperationException(ex.Message, ex); }

            return lines;
        }
    }
}
