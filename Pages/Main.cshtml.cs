using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;

namespace Portfolio.Pages
{
    public class MainModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly PortfolioContext _context;
        public IEnumerable<Article> Articles { get; private set; }

        public MainModel(ILogger<PrivacyModel> logger, PortfolioContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Articles = _context.Articles.Include(p => p.Paragraphs).ToList();
        }
    }
}
