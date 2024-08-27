using Microsoft.EntityFrameworkCore;
using UrlShortenerService.Core.Entities;
using UrlShortenerService.Core.Interfaces;
using UrlShortenerService.Infrastructure.Context;

namespace UrlShortenerService.Infrastructure.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlShortenerDbContext _context;

        public UrlRepository(UrlShortenerDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ShortUrl shortUrl)
        {
            _context.ShortUrls.Add(shortUrl);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var shortUrl = await _context.ShortUrls.FindAsync(id);
            if (shortUrl != null)
            {
                _context.ShortUrls.Remove(shortUrl);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ShortUrl> GetByIdAsync(int id)
        {
            return await _context.ShortUrls.FindAsync(id);
        }

        public async Task<ShortUrl> GetByShortUrlAsync(string shortUrl)
        {
            return await _context.ShortUrls.FirstOrDefaultAsync(u => u.ShortenedUrl == shortUrl);
        }

        public async Task UpdateAsync(ShortUrl shortUrl)
        {
            _context.ShortUrls.Update(shortUrl);
            await _context.SaveChangesAsync();
        }
    }
}
