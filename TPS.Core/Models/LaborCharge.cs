using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPS.Core.Models
{
    public class LaborCharge
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public double EstimatedHours { get; set; }
        public double? ActualHours { get; set; }

        public decimal ChargedAmount { get; set; } = 0;

        public int PayPeriodId { get; set; }
        public PayPeriod PayPeriod { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string ChargeCode { get; set; }
        
        public Guid? TaskBaseClassId { get; set; }
        public TaskBaseClass TaskBaseClass { get; set; }
    }
}
