namespace MachineLearningMachine3000.Forecast
{
    public class ForecastParameter
    {
        public int windowSize { get; set; }
        public int seriesLength { get; set; }
        public int trainSize { get; set; }
        public int horizon { get; set; }

        public float confidenceLevel { get; set; }
    }
}
