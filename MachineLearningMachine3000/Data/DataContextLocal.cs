using MachineLearningMachine3000.Shared.Entities;
using Microsoft.EntityFrameworkCore;


namespace MachineLearningMachine3000.Data
{
    public class DataContextLocal: DbContext
    {
        public DataContextLocal(DbContextOptions<DataContextLocal> options)
        : base(options)
        {
        }
        public DbSet<FactCaseForecast> FactCasesForecast { get; set; }

    }
    
}
