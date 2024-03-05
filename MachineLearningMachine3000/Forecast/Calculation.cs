using 
using System.Data;

namespace MachineLearningMachine3000.Forecast
{
    public class Calculation
    {
        static readonly string _dataPath = "C:\\Users\\TimStorbeck\\source\\repos\\ForecastingDP\\ForecastingDP\\VorherSchnittAnfang.csv"; // Path to your CSV file
        static readonly string _endDataPath = "C:\\Users\\TimStorbeck\\source\\repos\\ForecastingDP\\ForecastingDP\\Nachher_2202Bis0403.csv"; // Path to your CSV file
        
            MLContext mlContext = new MLContext();


            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                _dataPath,
                hasHeader: true,
                separatorChar: ',');

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
                horizon: 38,
                confidenceLevel: 0.95f,
                confidenceLowerBoundColumn: nameof(ModelOutput.ConfidenceIntervalLowerBounds),
                confidenceUpperBoundColumn: nameof(ModelOutput.ConfidenceIntervalUpperBounds)
                );




            var model = forecastingPipeline.Fit(dataView);


            var forecastingEngine = model.CreateTimeSeriesEngine<ModelInput, ModelOutput>(mlContext);
            ModelOutput forecast = forecastingEngine.Predict();

            DateTime enddate = new DateTime(2024, 01, 27);

            using (StreamWriter sw = File.CreateText(_endDataPath))
            {
                for (int i = 0; i < forecast.ForecastedValues.Length; i++)
                {
                    sw.WriteLine($"{Convert.ToInt32(forecast.ForecastedValues[i])}, {int.Parse(enddate.AddDays(1 + i).ToString("yyyyMMdd"))}");
                }
            }
            /*, {forecast.ForecastedValues[i]}, {forecast.ForecastedValues[i]}*/

            Console.WriteLine("Forecasted Values:");
            foreach (var value in forecast.ForecastedValues)
            {
                Console.WriteLine(value);
            }

            //Plotter.Plot(_endDataPath);


        
    }

    
}
