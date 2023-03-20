using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Data.Models;

namespace UrlShortener.Domain.Repositories
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly AppDbContext _dbContext;
        public ShortUrlRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string? GetPath(string destination)
        {
            var result = _dbContext.ShortUrls.FirstOrDefault(x => destination == x.Destination)?.Path;
            return result;
        }

        public string? GetDestination(string path)
        {
            var result = _dbContext.ShortUrls.FirstOrDefault(x => path == x.Path)?.Destination;
            return result;
        }

        public List<string> GetShortUrls()
        {
            var result = _dbContext.ShortUrls.Select(x => x.Path).ToList();
            return result;
        }

        public void CreateUrl(Guid id, string destination, string path)
        {
            _dbContext.ShortUrls.Add(
            new ShortUrl
            {
                ShortUrlId = id,
                Destination = destination,
                Path = path
            });
            _dbContext.SaveChanges();

            return;
        }
    }
}
