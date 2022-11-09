using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using WebApplication1.Data;
using WebApplication1.Models;
using Message = Microsoft.DotNet.Scaffolding.Shared.Messaging.Message;

namespace WebApplication1.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.Data.AppDbContext _context;

        public CreateModel(WebApplication1.Data.AppDbContext context)
        {
            _context = context;
        }

        public List<Groups_Class> AllGroup { get; set; }
        public IActionResult OnGet()
        {
            AllGroup = _context.Groups_Class.ToList();
            return Page();
        }

        [BindProperty]
        public Items_Class Items_Class { get; set; }
        public string Message { get; private set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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

            _context.Items_Class.Add(Items_Class);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
