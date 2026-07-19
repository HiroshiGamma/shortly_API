using Shortly.Application.DTOs;

namespace Shortly.Application.Interfaces;

public interface ILinkService
{
    Task<LinkResponse> CreateLink(string url, long userId);

    Task<LinkResponse> IncrementClicks(long linkId);

    Task<LinkResponse> GetLink(string shortUrl);

    Task<LinkResponse> GetLinkById(long linkId);

    Task<List<LinkResponse>> GetAllLinks();

    Task<List<LinkResponse>> GetLinksByUserId(long userId);

    Task DeleteLink(long linkId);

    Task<UsageStatisticsResponse> GetStatistics();
}
