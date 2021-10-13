using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentRazor.DbModel;
using System.IO;
using System.Threading.Tasks;

namespace RentRazor.Pages
{
    public class AddPagesModel : PageModel
    {
        [BindProperty]
        public AddressOfProperty AddressOfProperty { get; set; }

        [BindProperty]
        public Property Property { get; set; }

        [BindProperty]
        public string ImagePath { get; set; }

        private readonly RentRazor.DbModel.RentPropertyContext _context;

        public AddPagesModel(RentRazor.DbModel.RentPropertyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            ViewData["PropertyType"] = new SelectList(_context.PropertyTypes, "Id", "Adress");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AddressOfProperties.Add(AddressOfProperty);
            _context.Properties.Add(Property);

            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }


    }
}
