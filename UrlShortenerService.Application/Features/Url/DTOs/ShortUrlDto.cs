namespace UrlShortenerService.Application.Features.Url.DTOs
{
    public record ShortUrlDto(
           int Id,
           string OriginalUrl,
           string ShortenedUrl,
           int AccessCount,
           DateTime CreatedAt
        );


}
