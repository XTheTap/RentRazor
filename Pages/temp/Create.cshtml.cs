using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentRazor.DbModel;

namespace RentRazor.Pages.temp
{
    public class CreateModel : PageModel
    {
        private readonly RentRazor.DbModel.RentPropertyContext _context;

        public CreateModel(RentRazor.DbModel.RentPropertyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
       
            ViewData["PropertyType"] = new SelectList(_context.PropertyTypes, "Id", "Adress");
            return Page();
        }

        [BindProperty]
        public Property Property { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Properties.Add(Property);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
