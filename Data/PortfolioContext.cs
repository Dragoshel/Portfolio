using Microsoft.EntityFrameworkCore;

using Portfolio.Models;

namespace Portfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}