namespace UrlShortener.WebApplication.Models
{
    public class UrlViewModel
    {
        public int UrlId { get; set; }
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}