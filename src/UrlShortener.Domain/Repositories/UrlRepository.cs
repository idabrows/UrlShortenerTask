using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Domain.Models;

namespace UrlShortener.Domain.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        public string CreateUrl(string url)
        {
            var shortUrl = url;
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("UrlShortenerDb").Options;
            using (var context = new AppDbContext(options))
            {
                var result = context.Urls.Add(      
                new Data.Models.Url{
                    LongUrl = url,
                    ShortUrl = shortUrl,
                    CreatedAt = DateTime.UtcNow
                });
                
                context.SaveChanges();

                return shortUrl;
            }
        }

        List<UrlItem> IUrlRepository.GetUrls()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("UrlShortenerDb").Options;
            using (var context = new AppDbContext(options))
            {
                var result = context.Urls
                            .Select(x => new Domain.Models.UrlItem
                            {
                                UrlId = x.UrlId,
                                LongUrl = x.LongUrl,
                                ShortUrl = x.ShortUrl
                            })
                            .ToList();
                return result;
            }
        }
    }
}
