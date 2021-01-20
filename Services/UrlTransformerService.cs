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

        public bool IsValidPath(PathString path, string valueToCheck)
        {
            var pathToCheck = new PathString("/" + valueToCheck);

            return path.StartsWithSegments(pathToCheck);
        }

        public async Task<Article> GetArticleFromPathId(PathString path)
        {
            string[] segments = path.Value.Split("/");
            string title = segments[2];

            return (await GetArticleFromTitleId(title));
        }

        public async Task<Article> GetArticleFromTitleId(string title)
        {
            string[] words = title.Split("-");
            int Id = int.Parse(words[words.Length - 1]);

            var article = await _context.Articles
                                        .Include(p => p.Paragraphs)
                                        .FirstOrDefaultAsync(a => a.Id == Id);

            return article;
        }

        public async Task<string> TransformUrl(PathString path)
        {
            var article = await GetArticleFromPathId(path);

            string formattedTitle = article.Title.Replace(' ', '-');

            formattedTitle += ("-" + article.Id);

            return formattedTitle;
        }
    }
}