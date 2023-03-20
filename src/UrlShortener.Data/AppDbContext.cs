using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Models;

namespace UrlShortener.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}

        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<RequestUrlLog> RequestUrlLogs { get; set; }
    }
}
