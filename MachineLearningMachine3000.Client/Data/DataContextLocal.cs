using MachineLearningMachine3000.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MachineLearningMachine3000.Client.Data
{
    public class DataContextLocal : DbContext
    {
        public DataContextLocal(DbContextOptions<DataContextLocal> option) : base(option)
        {

        }
        public DbSet<FactCaseForecast> FactCasesForecast { get; set; }

    }
}
