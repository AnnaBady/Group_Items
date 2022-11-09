using System;
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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.Data.AppDbContext _context;

        public DetailsModel(WebApplication1.Data.AppDbContext context)
        {
            _context = context;
        }

      public Groups_Class Groups_Class { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Groups_Class == null)
            {
                return NotFound();
            }

            var groups_class = await _context.Groups_Class.FirstOrDefaultAsync(m => m.Id == id);
            if (groups_class == null)
            {
                return NotFound();
            }
            else 
            {
                Groups_Class = groups_class;
            }
            return Page();
        }
    }
}
