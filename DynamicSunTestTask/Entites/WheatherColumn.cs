namespace DynamicSunTestTask.Entites
{
    public class WheatherColumn
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public string MoscowTime { get; set; } = null!;
        public double Temperature { get; set; }
        public double AirHumidity { get; set; }
        public double DewPoint { get; set; }
        public double Pressure { get; set; }
        public string? DirectionOfTheWind { get; set; }
        public double? WindSpeed { get; set; }
        public double? Cloudy { get; set; }
        public double? LowerCloudLimit { get; set; }
        public double? HorizontalVisibility { get; set; }
        public string? WeatherConditions { get; set; }
    }
}