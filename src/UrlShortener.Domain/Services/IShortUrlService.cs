using UrlShortener.Data.Models;
namespace UrlShortener.Domain.Services
{
    public interface IShortUrlService
    {
        string? GetDestination(string path);
        List<string> GetShortUrls();
        string? CreateUrl(string destination);
    }
}
