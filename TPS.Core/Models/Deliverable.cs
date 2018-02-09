using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPS.Core.Models
{
    public class Deliverable
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }

        private string _currentStatus;

        [Display(Name = "Current Status")]
        [Required(AllowEmptyStrings = false)]
        public string CurrentStatus
        {
            get => _currentStatus;
            set
            {
                _currentStatus = value;
                _currentStatusAsOf = DateTime.Today;
            }
        }

        [DataType(DataType.Date)]
        private DateTime _currentStatusAsOf;

        [DataType(DataType.Date)]
        public DateTime CurrentStatusAsOf => _currentStatusAsOf;

        public int FormatId { get; set; }
        public Format Format { get; set; }

        public bool Formal { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEstimatedDue { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateDelivered { get; set; }

        public Guid? PublicationId { get; set; }
        public Publication Publication { get; set; }

        public Guid? ContractId { get; set; }
        public Contract Contract { get; set; }

        public Guid? TaskBaseClassId { get; set; }
        public TaskBaseClass TaskBaseClass { get; set; }
        
    }
}
