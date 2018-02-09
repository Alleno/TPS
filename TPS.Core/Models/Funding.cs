using System;
using System.ComponentModel.DataAnnotations;

namespace TPS.Core.Models
{
    public class Funding
    {
        public Guid Id { get; set; }
        
        [Display(Name = "Date Funding Approved")]
        [DataType(DataType.Date)]
        public DateTime DateApproved { get; set; }
        
        [Display(Name = "Funding Amount")]
        [DisplayFormat(NullDisplayText = "No Funding")]
        public decimal FundingAmount { get; set; }

        [Display(Name = "Funding Category")]
        [DisplayFormat(NullDisplayText = "No Funding Category")]
        public int? FundingCategoryId { get; set; }
        public FundingCategory FundingCategory { get; set; }
    }
}