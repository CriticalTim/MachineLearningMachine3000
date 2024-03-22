using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MachineLearningMachine3000.Shared.Entities;
using MachineLearningMachine3000.Forecast;

namespace MachineLearningMachine3000.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        Calculation calc = new Calculation();

        [HttpGet("calculate")]
        public async Task<ActionResult<List<ResultSet>>> GetCalculation(List<FactCase> factCases, ForecastParameter forecastParameter)
        {

           var results = calc.ForecastCalculate(factCases, forecastParameter);
           return Ok(results);

        }

        [HttpGet("recalculate")]
        public async Task<ActionResult<List<ResultSet>>> GetRecalculation(List<FactCaseForecast> factCases, ForecastParameter forecastParameter)
        {

            var results = calc.ForecastRecalculate(factCases, forecastParameter);
            return Ok(results);

        }
    }
}
