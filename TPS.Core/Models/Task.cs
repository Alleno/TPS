using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TPS.Core.Models
{
    public class TaskBaseClass
    {
        public Guid Id { get; set; }
        public Guid TaskLeaderId { get; set; }
        public Employee TaskLeader { get; set; }

        public string Title { get; set; }
        public string ShortTitle { get; set; }
        
        public int DivisionId { get; set; }
        public Division Division { get; set; }

        [Display(Name="IDA Core Area")]
        public int IDACoreAreaId { get; set; }
        public IDACoreArea IDACoreArea { get; set; }

        [Display(Name="SFRD Program Area")]
        public int SFRDProgramAreaId { get; set; }
        public SFRDProgramArea SFRDProgramArea { get; set; }
        
        //public IEnumerable<string> KeyWords { get; set; }
        public IEnumerable<Deliverable> Deliverables { get; set; }
        public IEnumerable<LaborCharge> LaborCharges { get; set; }
        public IEnumerable<NonLaborCharge> NonLaborCharges { get; set; }


        //public ICollection<string> ChargeCodes { get; set; } 
    }

    public class Task : TaskBaseClass
    {
        public Guid TaskOrderId { get; set; } //FK on Task Order
        public TaskOrder TaskOrder { get; set; }
        // Task Budget is determined from Task Order and amendments, can apportion part of budget to sub tasks,
        // but the overall task budget is set by the task order and amendments

        public IEnumerable<SubTask> SubTasks { get; set; }
    }

    public class SubTask : TaskBaseClass
    {
        public Guid TaskId { get; set; } // FK on task
        public Task Task { get; set; }

        public IEnumerable<Funding> Fundings { get; set; }
    }

    public class CRP : TaskBaseClass
    {
        public int CRPCategory { get; set; }
        public IEnumerable<Funding> Fundings { get; set; } // Maybe instead of a budget we need a funding source here?
    }
}
