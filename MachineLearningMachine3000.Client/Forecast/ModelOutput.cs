namespace MachineLearningMachine3000.Client.Forecast
{
    public class ModelOutput
    {
        public float[] ForecastedValues { get; set; }

        public float[] ConfidenceIntervalLowerBounds { get; set; }
        public float[] ConfidenceIntervalUpperBounds { get; set; }
    }
}
