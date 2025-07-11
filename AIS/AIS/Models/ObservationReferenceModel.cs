using System;

namespace AIS.Models
{
    public class ObservationReferenceModel
    {
        public int ComId { get; set; }
        public string ParaTitle { get; set; }
        public int? ReferenceId { get; set; }
        public string ReferenceType { get; set; }
        public string AssignedAuditor { get; set; }
        public string Status { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string Remarks { get; set; }
    }

    public class ObservationReferenceLogModel
    {
        public DateTime Date { get; set; }
        public string User { get; set; }
        public string FieldChanged { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Action { get; set; }
    }
}
