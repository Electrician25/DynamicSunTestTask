namespace DynamicSunTestTask.Entites
{
	public class WheatherColumnEntity
	{
		public int ID { get; set; }
		public int Date { get; set; }
		public string MoskowTime { get; set; } = null!;
		public double Temperature { get; set; }
		public double AirHumidity { get; set; }
		public double DewPoint { get; set; }
		public int Pressure { get; set; }
		public string? DirectionOfTheWind { get; set; }
		public string? WindSpeed { get; set; }
		public int Cloudy { get; set; }
		public int lowerCloudLimit { get; set; }
		public int HorizontalVisibility { get; set; }
		public string? WeatherConditions { get; set; }
	}
}