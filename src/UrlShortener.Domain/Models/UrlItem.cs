namespace UrlShortener.Domain.Models
{
    public class UrlItem
    {
        public int UrlId { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}