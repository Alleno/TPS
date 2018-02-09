using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TPS.Core.Models;

namespace DataAccessOld.OriginalModels
{
    [Table("PROJ")]
    public class CRP
    {
        [Key]
        [Column("PROJ_ID")]
        public string Id { get; set; }

        [Column("PROJ_NAME")]
        public string Name { get; set; }

        [Column("ACTIVE_FL")]
        public string Active { get; set; }

        [Column("LVL_NO")]
        public Int16 Level { get; set; }

    }
}
