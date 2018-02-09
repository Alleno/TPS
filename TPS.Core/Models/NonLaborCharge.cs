using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPS.Core.Models
{
    public class NonLaborCharge
    {
        public Guid Id { get; set; }

        public int ChargeTypeId { get; set; }
        public ChargeType ChargeType { get; set; }

        public decimal EstimatedAmount { get; set; } = 0;
        public decimal ChargedAmount { get; set; } = 0;

        [DataType(DataType.Date)]
        [Display(Name = "Actual date of charge")]
        public DateTime? ActualDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Planned date of charge")]
        public DateTime PlannedDate { get; set; }

        public string ChargeCode { get; set; }
        
        public Guid TaskBaseClassId { get; set; }
        public TaskBaseClass TaskBaseClass { get; set; }
    }
}
