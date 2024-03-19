using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MachineLearningMachine3000.Shared.Entities
{
    
    //[Table("Fact_Cases_Forecast", Schema = "DP_FC_156")]
    public partial class FactCaseForecast
    {
        [Key]
        public int DateId { get; set; }

        [Required]
        public int SummeVonEingangNeuForecast { get; set; }

    }
}
