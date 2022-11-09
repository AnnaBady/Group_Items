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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Data.AppDbContext _context;

        public DeleteModel(WebApplication1.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Groups_Class == null)
            {
                return NotFound();
            }
            var groups_class = await _context.Groups_Class.FindAsync(id);

            if (groups_class != null)
            {
                Groups_Class = groups_class;
                _context.Groups_Class.Remove(Groups_Class);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
