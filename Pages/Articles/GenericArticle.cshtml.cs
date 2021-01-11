using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using Models;
using Data;

namespace Portfolio.Pages
{
    public class GenericArticleModel : PageModel
    {
        public Article Article { get; private set; }
        public string RouteDataTitleValue { get; private set; }
        public GenericArticleModel()
        {

        }
        public void OnGet()
        {
            var titleValue = RouteData.Values["title"];

            if (titleValue != null)
            {
                RouteDataTitleValue = (string)titleValue;
            }

            
        }
    }
}