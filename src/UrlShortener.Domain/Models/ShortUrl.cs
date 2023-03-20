using Microsoft.AspNetCore.WebUtilities;

namespace UrlShortener.Domain.Models
{
    public class ShortUrl
    {
        public string Destination { get; set; }
        public string Path { get; set; }
    }

}