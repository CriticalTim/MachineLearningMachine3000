using Microsoft.EntityFrameworkCore;
using MachineLearningMachine3000.Shared;

namespace MachineLearningMachine3000.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> option): base(option) 
        {
            
        }

        public DbSet<FactCase> FactCases { get; set; }

    }
}
