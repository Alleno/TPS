using System;
using System.Collections.Generic;
using System.Text;

namespace TPS.Core.Models
{
    public class FundingCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AnticipatedAudience
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class VisibilityLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ApprovalStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
