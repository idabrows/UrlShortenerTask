using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Repositories
{
    public interface IUrlRepository
    {
        List<UrlItem> GetUrls();
        string CreateUrl(string url);
    }
}
