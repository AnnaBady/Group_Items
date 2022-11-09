﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Groups
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.AppDbContext _context;

        public IndexModel(WebApplication1.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Groups_Class> Groups_Class { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Groups_Class != null)
            {
                Groups_Class = await _context.Groups_Class.ToListAsync();
            }
        }
    }
}
