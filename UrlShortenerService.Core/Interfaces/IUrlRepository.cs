using UrlShortenerService.Core.Entities;

namespace UrlShortenerService.Core.Interfaces
{
    public interface IUrlRepository
    {
        Task<ShortUrl> GetByIdAsync(int id);
        Task<ShortUrl> GetByShortUrlAsync(string shortUrl);
        Task AddAsync(ShortUrl shortUrl);
        Task UpdateAsync(ShortUrl shortUrl);
        Task DeleteAsync(int id);
    }
}
