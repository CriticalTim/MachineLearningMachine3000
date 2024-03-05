using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.TimeSeries;
using Microsoft.ML.Transforms.TimeSeries;
//using OxyPlot;
//using OxyPlot.Series;
using System.IO;
using System.Data;
using MachineLearningMachine3000.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace MachineLearningMachine3000.Forecast
{
    public class Calculation
    {
        
        public List<ResultSet> ForecastCalculate(List<FactCase> factCases)
        {
            
            List<ModelInput> data = new List<ModelInput>();
            List<ResultSet> results = new List<ResultSet>();
            int i= 0;

            DateTime startDate = DateTime.ParseExact(factCases.Select(x => x.DateId).Last().ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);

            foreach (var factCase in factCases)
            {
                data.Add(new ModelInput
                {
                    Time = DateTime.ParseExact(factCase.DateId.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture),
                    Value = factCase.SummeVonEingangNeu
                });
            }


            MLContext mlContext = new MLContext();

            IDataView dataView = mlContext.Data.LoadFromEnumerable(data);
        

        //var iidSpikeEstimator = mlContext.Transforms.DetectIidSpike(
        //        outputColumnName: "Prediction",
        //            inputColumnName: nameof(ModelInput.Value),
        //        confidence: 95,
        //    pvalueHistoryLength: 12
        //    );

        //var iidSpikeTransform = iidSpikeEstimator.Fit(dataView);
        //var iidSpikeTransformedData = iidSpikeTransform.Transform(dataView);

            var forecastingPipeline = mlContext.Forecasting.ForecastBySsa(
                outputColumnName: nameof(ModelOutput.ForecastedValues),
                inputColumnName: nameof(ModelInput.Value),
                windowSize: 7,
                seriesLength: 1183,
                trainSize: 1000,
                horizon: 500,
                confidenceLevel: 0.95f,
                confidenceLowerBoundColumn: nameof(ModelOutput.ConfidenceIntervalLowerBounds),
                confidenceUpperBoundColumn: nameof(ModelOutput.ConfidenceIntervalUpperBounds)
                );

            var model = forecastingPipeline.Fit(dataView);


            var forecastingEngine = model.CreateTimeSeriesEngine<ModelInput, ModelOutput>(mlContext);
            ModelOutput forecasts = forecastingEngine.Predict(); 

            

            foreach (var forecast in forecasts.ForecastedValues)
            {
                
                results.Add(new ResultSet
                {
                    Date = startDate.AddDays(1 + i),
                    Value = Convert.ToInt32(forecast)
                });
                i++;
            }


            return results;

        }              
    }   
}
