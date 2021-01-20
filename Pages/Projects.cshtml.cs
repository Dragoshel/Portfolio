using Microsoft.AspNetCore.Mvc.RazorPages;

using Portfolio.Data;
using Portfolio.Models;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace Portfolio.Pages
{
    public class ProjectsModel : PageModel
    {
        private readonly PortfolioContext _context;

        public Article[] Articles { get; set; }

        public ProjectsModel(PortfolioContext context)
        {
            _context = context;
        }

        public async Task OnGet()
        {
            Articles = await _context.Articles.ToArrayAsync();
        }
    }
}