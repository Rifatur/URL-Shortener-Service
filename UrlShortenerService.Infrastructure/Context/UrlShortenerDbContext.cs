using Microsoft.EntityFrameworkCore;
using UrlShortenerService.Core.Entities;

namespace UrlShortenerService.Infrastructure.Context
{
    public class UrlShortenerDbContext : DbContext
    {
        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options) : base(options) { }

        public DbSet<ShortUrl> ShortUrls { get; set; }

    }
}
