using Portfolio.IServices;
using Portfolio.Data;
using Portfolio.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Portfolio.Services
{
    public class UrlTransformerService : IUrlTransformerService
    {
        private readonly PortfolioContext _context;

        public UrlTransformerService(PortfolioContext context)
        {
            _context = context;
        }

        public bool IsValidArticlePath(PathString path)
        {
            var articlePath = new PathString("/Articles");

            return (path.StartsWithSegments(articlePath));
        }

        private async Task<Article> GetArticleFromPathId(PathString path)
        {
            string[] segments = path.Value.Split("/");
            string title = segments[2];

            string[] words = title.Split("-");
            int Id = int.Parse(words[words.Length - 1]);

            var article = await _context.Articles
                                        .FirstOrDefaultAsync(a => a.Id == Id);

            return article;
        }

        public async Task<string> TransformUrl(HttpContext httpContext)
        {
            var path = httpContext.Request.Path;
            var article = await GetArticleFromPathId(path);

            string formattedTitle = "/Articles/" + article.Title.Replace(' ', '-');

            formattedTitle += ("-" + article.Id);

            return formattedTitle;
        }
    }
}