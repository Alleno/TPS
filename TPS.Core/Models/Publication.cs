using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TPS.Core.Models
{
    public class Publication
    {
        [Key]
        public Guid DeliverableId { get; set; }
        public Deliverable Deliverable { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Display(Name = "Estimated Number of Pages")]
        public int? EstimatedNumPages { get; set; }

        [Display(Name = "Actual Number of Pages")]
        public int? ActualNumPages { get; set; }

        public Guid NonLaborChargeId { get; set; }
        public NonLaborCharge PubsCost { get; set; }

    }
}
