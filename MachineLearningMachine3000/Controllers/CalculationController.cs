using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MachineLearningMachine3000.Shared.Entities;
using MachineLearningMachine3000.Forecast;
using System.Text.Json;

namespace MachineLearningMachine3000.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        Calculation calc = new Calculation();


        [HttpPost("calculate")]
        public async Task<ActionResult<List<ResultSet>>> GetCalculation(ResultSetParameterWrapper wrapper)
        {
            try
            {
    
                var calc = new Calculation();

                var results = calc.ForecastCalculate(wrapper.FactCases, wrapper.ForecastParameter);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("recalculate")]
        public async Task<ActionResult<List<ResultSet>>> GetRecalculation(ResultSetParameterForecastWrapper wrapper)
        {
            try
            {

                var calc = new Calculation();

                var results = calc.ForecastRecalculate(wrapper.FactCasesForecast , wrapper.ForecastParameter);

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
