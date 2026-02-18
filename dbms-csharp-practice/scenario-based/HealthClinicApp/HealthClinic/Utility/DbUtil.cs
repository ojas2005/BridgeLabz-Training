using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HealthClinic.Utility
{
    internal static class DbUtil
    {
        public static void AddNullable(SqlCommand cmd, string name, object? value, SqlDbType? dbType = null)
        {
            var p = cmd.Parameters.Add(name, dbType ?? SqlDbType.Variant);
            p.Value = value ?? DBNull.Value;
        }
    }
}
