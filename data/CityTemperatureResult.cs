public class CityTemperatureResult
{
    public bool IsFound { get; set; }
    public string Message { get; set; } = null!;
    public string? CityName { get; set; }
    public double? AvgTemperature { get; set; }
}
