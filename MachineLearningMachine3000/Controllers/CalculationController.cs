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
        public async Task<ActionResult<List<ResultSet>>> GetCalculation()
        {
            var endresult = new ResultSetParameterWrapper();

            try
            {
                if (!Request.HasFormContentType)
                {
                    return BadRequest("Unsupported media type");
                }

                var form = await Request.ReadFormAsync();
                var calc = new Calculation();

                // Deserialize FactCases
                if (form.TryGetValue("FactCases", out var factCasesJson))
                {
                    endresult.FactCases = JsonSerializer.Deserialize<List<FactCase>>(factCasesJson);
                }

                // Deserialize ForecastParameter
                if (form.TryGetValue("ForecastParameter", out var forecastParameterJson))
                {
                    endresult.ForecastParameter = JsonSerializer.Deserialize<ForecastParameter>(forecastParameterJson);
                }

                if(endresult == null || endresult.FactCases == null || endresult.ForecastParameter == null)
                {
                    return BadRequest("One or more Values were null");
                }
                var results = calc.ForecastCalculate(endresult.FactCases, endresult.ForecastParameter);

               

                return Ok(results);
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
