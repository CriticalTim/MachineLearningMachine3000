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

        [HttpPost("calculate")]
        public async Task<ActionResult<ResultSetParameterWrapper>> GetCalculation(ResultSetParameterWrapper wrapper)
        {
            ResultSetParameterWrapper endresult = new ResultSetParameterWrapper();
            var results = calc.ForecastCalculate(wrapper.FactCases, wrapper.ForecastParameter);
            endresult.ResultSet = results; 
           return Ok(endresult);

        }

        [HttpPost("recalculate")]
        public async Task<ActionResult<ResultSetParameterWrapper>> GetRecalculation(ResultSetParameterWrapper wrapper)
        {
            ResultSetParameterWrapper endresult = new ResultSetParameterWrapper();
            var results = calc.ForecastRecalculate(wrapper.FactCaseForecasts, wrapper.ForecastParameter);
            endresult.ResultSet = results;
            return Ok(endresult);

        }
    }
}
