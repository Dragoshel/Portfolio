using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Portfolio.Models;

namespace Portfolio.IServices
{
    public interface IUrlTransformerService
    {
        bool IsValidPath(PathString path, string valueToCheck);
        Task<string> TransformUrl(PathString path);
        Task<Article> GetArticleFromPathId(PathString path);
        Task<Article> GetArticleFromTitleId(string title);
    }
}