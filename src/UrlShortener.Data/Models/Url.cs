namespace UrlShortener.Data.Models
{
    public class Url
    {
        public int UrlId { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}