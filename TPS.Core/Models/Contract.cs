using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TPS.Core.Models
{
    public class Contract
    {
        [Key]
        public Guid Id { get; set; } // Primary Key

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Abstract { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Objective { get; set; }

        [Display(Name = "Task Number")]
        public string TaskNumber { get; set; }

        [Display(Name = "Approval Status")]
        public int ApprovalStatusId { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }

        [Display(Name = "ActualDate Approved")]
        [DataType(DataType.Date)]
        public DateTime? DateApproval { get; set; }

        // If Status is Proposed Task, then ProjectNumber is null
        [Display(Name = "Project Number")]
        public string ProjectNumber { get; set; }

        [Display(Name = "Funding")]
        public Guid? FundingId { get; set; }
        public Funding Funding { get; set; }

        [Display(Name = "ActualDate Signed By Sponsor")]
        [DataType(DataType.Date)]
        public DateTime? DateSignedBySponsor { get; set; }

        [Display(Name = "PoP Begin Date")]
        [DataType(DataType.Date)]
        public DateTime? DateStart { get; set; }

        [Display(Name = "PoP End Date")]
        [DataType(DataType.Date)]
        public DateTime? DateEnd { get; set; }

        [Display(Name = "Anticipated Audience")]
        public int AnticipatedAudienceId { get; set; }
        public AnticipatedAudience AnticipatedAudience { get; set; }

        [Display(Name = "Visibility Level")]
        public int VisibilityLevelId { get; set; }
        public VisibilityLevel VisibilityLevel { get; set; }

        public IEnumerable<Deliverable> Deliverables { get; set; }

        protected Contract() { }
    }

    public class TaskOrder : Contract
    {
        [Display(Name = "Sponsor")]
        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }

        [Display(Name = "ActualDate Placed On Contract")]
        [DataType(DataType.Date)]
        public DateTime? DatePlacedOnContract { get; set; }

        public Guid? TaskId { get; set; }
        public Task Task { get; set; }

        public IEnumerable<Amendment> Amendments { get; set; }
        public TaskOrder() { }
    }
    
    public class Amendment : Contract
    {
        [Display(Name = "Parent Task Order")]
        public Guid TaskOrderId { get; set; } // FK on task
        public TaskOrder TaskOrder { get; set; } 

        public Amendment() { }
    }
}

