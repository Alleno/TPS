using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessOld.OriginalModels
{
    public class Project
    {
        [Key]
        [Column("project_id")]
        public Guid Id { get; set; }

        [Column("version_number")]
        public int VersionNumber { get; set; }

        [Column("sponsor_code")]
        public string SponsorCode { get; set; }

        [Column("task_number")]
        public string TaskNumber { get; set; }

        [Column("subtask_number")]
        public string SubTaskNumber { get; set; }

        [Column("fy")]
        public int FiscalYear { get; set; }

        [Column("amendment_number")]
        public int AmendmentNumber { get; set; }

        [Column("funding_code")]
        public string FundingCode { get; set; }

        [Column("division_id")]
        public int DivisionId { get; set; } // Maybe needs a foreign key constraint?

        [Column("project_leader_id")]
        public Guid ProjectLeaderId { get; set; } // Maybe needs a foreign key constraint?

        [Column("short_title")]
        public string ShortTitle { get; set; }

        [Column("long_title")]
        public string LongTitle { get; set; }

        [Column("contract")]
        public string ContractNumber { get; set; }

        [Column("objective")]
        public string Objective { get; set; }

        [Column("abstract")]
        public string Abstract { get; set; }

        [Column("core_area_id")]
        public string CoreAreaId { get; set; }

        [Column("first_charged_on")]
        public DateTime FirstChargeDateTime { get; set; }

        [Column("last_charged_on")]
        public DateTime LastChargeDateTime { get; set; }

        [Column("signed_by_sponsor_on")]
        public DateTime SignedBySponsorDateTime { get; set; }

        [Column("updated_on")]
        public DateTimeOffset UpdatedOn { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("charge_code")]
        public string ChargeCode { get; set; }

        [Column("deltek_proj_id")]
        public string DeltekProjectId { get; set; }

        [Column("code")]
        public string ProjecteCode { get; set; }
    }
}
