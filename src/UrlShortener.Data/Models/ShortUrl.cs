using Microsoft.AspNetCore.WebUtilities;

namespace UrlShortener.Data.Models
{
    public class ShortUrl
    {
        public Guid ShortUrlId { get; set; }
        public string Destination { get; set; }
        public string Path { get; set; }
    }
}