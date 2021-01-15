using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Portfolio.IServices
{
    public interface IUrlTransformerService
    {
        bool IsValidArticlePath(PathString path);
        Task<string> TransformUrl(HttpContext httpContext);
    }
}