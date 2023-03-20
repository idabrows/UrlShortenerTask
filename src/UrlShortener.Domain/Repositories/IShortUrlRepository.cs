namespace UrlShortener.Domain.Repositories
{
    public interface IShortUrlRepository
    {
        string? GetPath(string destination);
        string? GetDestination(string path);
        List<string> GetShortUrls();
        void CreateUrl(Guid id, string destination, string path);
    }
}
