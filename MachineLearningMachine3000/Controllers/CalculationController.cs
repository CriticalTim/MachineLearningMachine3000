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
            try
            {
                ResultSetParameterWrapper endresult = new ResultSetParameterWrapper();
                var results = calc.ForecastCalculate(wrapper.FactCases, wrapper.ForecastParameter);
                await Task.Delay(10000);

                endresult.ResultSet = results;
                return Ok(endresult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

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
