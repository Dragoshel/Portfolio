using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using Portfolio.Data;

using Portfolio.Services;
using Portfolio.IServices;

namespace Portfolio.Areas.Articles.Pages
{
    public class IndexModel : PageModel
    {
        public Article Article { get; private set; }
        public string RouteDataTitleValue { get; private set; }
        private readonly PortfolioContext _context;
        private readonly IUrlTransformerService _service;
        public IndexModel(PortfolioContext context, IUrlTransformerService service)
        {
            _context = context;
            _service = service;
        }
        public async Task OnGet()
        {
            var titleValue = (string)RouteData.Values["title"];

            if (titleValue != null)
            {
                RouteDataTitleValue = titleValue;
                Article = await _service.GetArticleFromTitleId(titleValue);
            }
        }
    }
}