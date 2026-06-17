using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Connection
{
    internal class DB_Connection
    {
        private static readonly string connectionString = "Server=localhost,1433;Database=HealthClinicDB;User Id=sa;Password=Insane@1234;TrustServerCertificate=True;";

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
