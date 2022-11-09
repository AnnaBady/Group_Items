using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Items
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication1.Data.AppDbContext _context;

        public DeleteModel(WebApplication1.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Items_Class Items_Class { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Items_Class == null)
            {
                return NotFound();
            }

            var items_class = await _context.Items_Class.Include(i => i.Groups).FirstOrDefaultAsync(m => m.Id == id);

            if (items_class == null)
            {
                return NotFound();
            }
            else 
            {
                Items_Class = items_class;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Items_Class == null)
            {
                return NotFound();
            }
            var items_class = await _context.Items_Class.FindAsync(id);

            if (items_class != null)
            {
                Items_Class = items_class;
                _context.Items_Class.Remove(Items_Class);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
