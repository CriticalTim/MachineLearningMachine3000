namespace MachineLearningMachine3000.Shared
{
    public class ResultSet
    {
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public float ConfidenceIntervalLowerBounds { get; set; }
        public float ConfidenceIntervalUpperBounds { get; set; }
    }
}
