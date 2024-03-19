using MachineLearningMachine3000.Shared.Entities;
using Microsoft.EntityFrameworkCore;


namespace MachineLearningMachine3000.Client.Data
{
    public class DataContextLocal: DbContext
    {
        public DbSet<FactCaseForecast> FactCasesForecast { get; set; }

    }
}
