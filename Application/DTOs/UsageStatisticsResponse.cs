namespace Shortly.Application.DTOs;

public sealed class UsageStatisticsResponse
{
    public int TotalLinks { get; set; }

    public int TotalClicks { get; set; }

    public double AverageClicksPerLink { get; set; }

    public LinkResponse? MostClickedLink { get; set; }
}