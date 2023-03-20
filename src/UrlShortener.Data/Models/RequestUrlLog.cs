namespace UrlShortener.Data.Models
{
    public class RequestUrlLog
    {
        public int RequestUrlLogId { get; set; }
        public string Request { get; set; }
        public string? AdditionalInfo { get; set; }
        public DateTime SentAt { get; set; }
    }
}