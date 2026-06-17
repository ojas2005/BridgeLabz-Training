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
    public sealed class BillingUtility : IBillingUtility
    {
        // CREATE
        public void GenerateBill(int visitId)
        {
            if (visitId <= 0) throw new ValidationException("VisitId must be > 0.");
            Exec("clinic.SPBills_Generate", cmd => cmd.Parameters.AddWithValue("@visit_id", visitId));
        }

        public void AddBillItem(int billId, string itemName, decimal amount)
        {
            if (billId <= 0) throw new ValidationException("BillId must be > 0.");
            if (string.IsNullOrWhiteSpace(itemName)) throw new ValidationException("ItemName required.");
            if (amount <= 0) throw new ValidationException("Amount must be > 0.");

            Exec("clinic.SPBillItems_Insert", cmd =>
            {
                cmd.Parameters.AddWithValue("@bill_id", billId);
                cmd.Parameters.AddWithValue("@item_name", itemName.Trim());
                cmd.Parameters.AddWithValue("@amount", amount);
            });
        }

        // UPDATE
        public void UpdateBillItem(int itemId, string itemName, decimal amount)
        {
            if (itemId <= 0) throw new ValidationException("ItemId must be > 0.");
            if (string.IsNullOrWhiteSpace(itemName)) throw new ValidationException("ItemName required.");
            if (amount <= 0) throw new ValidationException("Amount must be > 0.");

            Exec("clinic.SPBillItems_Update", cmd =>
            {
                cmd.Parameters.AddWithValue("@item_id", itemId);
                cmd.Parameters.AddWithValue("@item_name", itemName.Trim());
                cmd.Parameters.AddWithValue("@amount", amount);
            });
        }

        public void RecordPayment(int billId, decimal amountPaid, string paymentMode, string? referenceNo)
        {
            if (billId <= 0) throw new ValidationException("BillId must be > 0.");
            if (amountPaid <= 0) throw new ValidationException("AmountPaid must be > 0.");
            if (string.IsNullOrWhiteSpace(paymentMode)) throw new ValidationException("PaymentMode required.");

            Exec("clinic.SPBills_RecordPayment", cmd =>
            {
                cmd.Parameters.AddWithValue("@bill_id", billId);
                cmd.Parameters.AddWithValue("@amount_paid", amountPaid);
                cmd.Parameters.AddWithValue("@payment_mode", paymentMode.Trim());
                DbUtil.AddNullable(cmd, "@reference_no", referenceNo, SqlDbType.VarChar);
            });
        }

        // DELETE
        public void DeleteBillItem(int itemId)
        {
            if (itemId <= 0) throw new ValidationException("ItemId must be > 0.");
            Exec("clinic.SPBillItems_Delete", cmd => cmd.Parameters.AddWithValue("@item_id", itemId));
        }

        // READ
        public List<string> OutstandingBillsLines()
        {
            var lines = new List<string>();

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPBills_Outstanding", con) { CommandType = CommandType.StoredProcedure };

                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var name = r.GetString(r.GetOrdinal("full_name"));
                    var count = r.GetInt32(r.GetOrdinal("total_unpaid"));
                    var due = r.GetDecimal(r.GetOrdinal("total_due"));
                    lines.Add($"{name} | Unpaid Bills: {count} | Due: {due}");
                }
            }
            catch (SqlException ex) { throw new DatabaseOperationException(ex.Message, ex); }

            return lines;
        }

        public List<string> RevenueReportLines(DateTime startDate, DateTime endDate)
        {
            var lines = new List<string>();

            try
            {
                using var con = DB_Connection.CreateConnection();
                using var cmd = new SqlCommand("clinic.SPBills_RevenueReport", con) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@start_date", startDate.Date);
                cmd.Parameters.AddWithValue("@end_date", endDate.Date);

                con.Open();
                using var r = cmd.ExecuteReader();
                while (r.Read())
                {
                    var doc = r.GetString(r.GetOrdinal("doctor_name"));
                    var rev = r.GetDecimal(r.GetOrdinal("total_revenue"));
                    lines.Add($"Dr.{doc} | Revenue: {rev}");
                }
            }
            catch (SqlException ex) { throw new DatabaseOperationException(ex.Message, ex); }

            return lines;
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
