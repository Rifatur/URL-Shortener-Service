namespace UrlShortenerService.Core.Entities
{
    public class ShortUrl
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortenedUrl { get; set; } = string.Empty;
        public int AccessCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
