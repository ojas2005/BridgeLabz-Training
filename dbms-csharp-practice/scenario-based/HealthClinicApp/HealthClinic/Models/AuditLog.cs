using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.Models
{
    public sealed class AuditLog
    {
        // Audit identification
        public long AuditId { get; set; }
        public DateTime ChangedAt { get; set; }
        
        // Change details
        public string TableName { get; set; } = "";
        public string ActionType { get; set; } = "";
        public string RecordPk { get; set; } = "";
        
        // User information
        public string? ChangedBy { get; set; }

        public override string ToString()
        {
            return $"Audit ID: {AuditId} | {TableName}.{RecordPk} | Action: {ActionType} | By: {ChangedBy} | At: {ChangedAt:yyyy-MM-dd HH:mm}";
        }
    }
}
