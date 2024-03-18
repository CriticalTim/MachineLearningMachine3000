namespace MachineLearningMachine3000.Client.Forecast
{
    public class ResultSet
    {
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public float ConfidenceIntervalLowerBounds { get; set; }
        public float ConfidenceIntervalUpperBounds { get; set; }
    }
}
