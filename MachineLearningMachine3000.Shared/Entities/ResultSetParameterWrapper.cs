using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningMachine3000.Shared.Entities
{
    public class ResultSetParameterWrapper
    {
        public List<ResultSet> ResultSet { get; set; }

        public List<FactCase> FactCases { get; set; }

        public List<FactCaseForecast> FactCaseForecasts { get; set; }

        public ForecastParameter ForecastParameter { get; set; }

    }
}
