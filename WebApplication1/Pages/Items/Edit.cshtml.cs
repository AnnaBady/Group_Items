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

namespace WebApplication1.Pages.Items
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.Data.AppDbContext _context;

        public EditModel(WebApplication1.Data.AppDbContext context)
        {
            _context = context;
        }

        public List<Groups_Class> AllGroup { get; set; }


        [BindProperty]
        public Items_Class Items_Class { get; set; } = default!;

        public string Message { get; private set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            AllGroup = _context.Groups_Class.ToList();
            if (id == null || _context.Items_Class == null)
            {
                return NotFound();
            }

            var items_class =  await _context.Items_Class.Include(i => i.Groups).FirstOrDefaultAsync(m => m.Id == id);
            if (items_class == null)
            {
                return NotFound();
            }
            Items_Class = items_class;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var GId = Items_Class.Groups.Id;
            if (GId == 0)
            {
                Message = "You must choose";
                AllGroup = _context.Groups_Class.ToList();
                return Page();
            }
            var Group = await _context.Groups_Class.SingleOrDefaultAsync(m => m.Id == GId);
            Items_Class.Groups = Group;

            _context.Attach(Items_Class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Items_ClassExists(Items_Class.Id))
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

        private bool Items_ClassExists(int id)
        {
          return _context.Items_Class.Any(e => e.Id == id);
        }
    }
}
