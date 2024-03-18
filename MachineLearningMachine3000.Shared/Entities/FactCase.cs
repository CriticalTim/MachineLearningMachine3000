using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineLearningMachine3000.Shared.Entities
{
    [Keyless]
    [Table("Fact_Cases", Schema = "DP_FC_156")]
    public partial class FactCase
    {
        public int DateId { get; set; }

        [Column("ServiceID_ID")]
        public int ServiceIdId { get; set; }

        [Column("Summe_von_Eingang_Neu")]
        public int SummeVonEingangNeu { get; set; }

        [Column("Summe_von_Eingang_Aktiv")]
        public int SummeVonEingangAktiv { get; set; }
    }

}

