using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPS.Core.Models
{
    public class PayPeriod
    {
        public int Id { get; set; }
        public int FiscalYear { get; set; }
        public int PeriodNumber { get; set; }
        public int SubPeriodNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime PeriodStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime PeriodEndDate { get; set; }
    }
}
