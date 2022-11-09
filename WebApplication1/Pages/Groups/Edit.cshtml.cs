using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Groups
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.Data.AppDbContext _context;

        public EditModel(WebApplication1.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Groups_Class Groups_Class { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Groups_Class == null)
            {
                return NotFound();
            }

            var groups_class =  await _context.Groups_Class.FirstOrDefaultAsync(m => m.Id == id);
            if (groups_class == null)
            {
                return NotFound();
            }
            Groups_Class = groups_class;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Groups_Class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Groups_ClassExists(Groups_Class.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Groups_ClassExists(int id)
        {
          return _context.Groups_Class.Any(e => e.Id == id);
        }
    }
}
