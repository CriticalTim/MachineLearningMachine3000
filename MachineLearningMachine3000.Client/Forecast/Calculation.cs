using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System.Data;
using System.Globalization;
using MachineLearningMachine3000.Shared.Entities;

namespace MachineLearningMachine3000.Client.Forecast
{
    public class Calculation
    {
        
        public List<ResultSet> ForecastCalculate(List<FactCase> factCases, ForecastParameter parameter)
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

            if (parameter.windowSize<3) parameter.windowSize = 3;
            if (parameter.windowSize > parameter.seriesLength) parameter.seriesLength = parameter.windowSize + 1;
            if (parameter.windowSize > ( parameter.trainSize*2)) parameter.trainSize =  (1 + parameter.windowSize)*2 ;
            if (parameter.horizon == 0 ) parameter.horizon = 1 ;
            if (parameter.confidenceLevel > 1) parameter.confidenceLevel = 0.99f;
            if(parameter.confidenceLevel < 0) parameter.confidenceLevel = 0 ;


            var forecastingPipeline = mlContext.Forecasting.ForecastBySsa(
                outputColumnName: nameof(ModelOutput.ForecastedValues),
                inputColumnName: nameof(ModelInput.Value),
                windowSize: parameter.windowSize,
                seriesLength: parameter.seriesLength,
                trainSize: parameter.trainSize,
                horizon: parameter.horizon,
                confidenceLevel: parameter.confidenceLevel,
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
        public List<ResultSet> ForecastRecalculate(List<FactCaseForecast> factCases, ForecastParameter parameter)
        {

            List<ModelInput> data = new List<ModelInput>();
            List<ResultSet> results = new List<ResultSet>();
            int i = 0;

            DateTime startDate = DateTime.ParseExact(factCases.Select(x => x.DateId).Last().ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);

            foreach (var factCase in factCases)
            {
                data.Add(new ModelInput
                {
                    Time = DateTime.ParseExact(factCase.DateId.ToString(), "yyyyMMdd", CultureInfo.InvariantCulture),
                    Value = factCase.SummeVonEingangNeuForecast
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

            if (parameter.windowSize < 3) parameter.windowSize = 3;
            if (parameter.windowSize > parameter.seriesLength) parameter.seriesLength = parameter.windowSize + 1;
            if (parameter.windowSize > (parameter.trainSize * 2)) parameter.trainSize = (1 + parameter.windowSize) * 2;
            if (parameter.horizon == 0) parameter.horizon = 1;
            if (parameter.confidenceLevel > 1) parameter.confidenceLevel = 0.99f;
            if (parameter.confidenceLevel < 0) parameter.confidenceLevel = 0;


            var forecastingPipeline = mlContext.Forecasting.ForecastBySsa(
                outputColumnName: nameof(ModelOutput.ForecastedValues),
                inputColumnName: nameof(ModelInput.Value),
                windowSize: parameter.windowSize,
                seriesLength: parameter.seriesLength,
                trainSize: parameter.trainSize,
                horizon: parameter.horizon,
                confidenceLevel: parameter.confidenceLevel,
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
