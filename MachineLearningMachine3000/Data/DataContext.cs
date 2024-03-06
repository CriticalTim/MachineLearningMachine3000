using Microsoft.EntityFrameworkCore;

namespace MachineLearningMachine3000.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> option): base(option) 
        {
            
        }

        public DbSet<FactCase> FactCases { get; set; }

        public DbSet<FactCaseForecast> FactCasesForecast { get; set; }

    }
}
