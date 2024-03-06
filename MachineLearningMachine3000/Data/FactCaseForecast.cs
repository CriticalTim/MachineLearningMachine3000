using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineLearningMachine3000.Data
{
    [Keyless]
    [Table("Fact_Cases_Forecast", Schema = "DP_FC_156")]
    public partial class FactCaseForecast
    {

        public int DateId { get; set; }

        [Column("Summe_von_Eingang_Neu_Forecast")]
        public int SummeVonEingangNeuForecast { get; set; }

    }
}
