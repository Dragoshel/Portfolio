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

namespace Portfolio.Areas.Articles.Pages
{
    public class IndexModel : PageModel
    {
        public Article Article { get; private set; }
        public string RouteDataTitleValue { get; private set; }
        private readonly PortfolioContext _context;
        public IndexModel(PortfolioContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            var titleValue = (string)RouteData.Values["title"];
            
            if (titleValue != null)
            {
                RouteDataTitleValue = titleValue;
            }
        }
    }
}