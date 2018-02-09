using System;
using System.Collections.Generic;
using System.Text;

namespace TPS.Core.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string BadgeId { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int EmployeeTypeId { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public IEnumerable<LaborCharge> LaborCharges { get; set; }
        public IEnumerable<Task> TasksLed { get; set; }
    }
}

