using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentRazor.DbModel;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace RentRazor.Pages
{
    public class AddPagesModel : PageModel
    {
        [BindProperty]
        public AddressOfProperty AddressOfProperty { get; set; }

        [BindProperty]
        public Property Property { get; set; }

        [DisplayName("Фотография")]
        [BindProperty]
        public IFormFile Photo { get; set; }

        public PhotoOfPropert PhotoOfPropert {  get; set; }

        private readonly RentPropertyContext _context;

        public AddPagesModel(RentPropertyContext context)
        {
            _context = context;
            PhotoOfPropert = new PhotoOfPropert();
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

            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                Photo.CopyTo(ms);
                fileBytes = ms.ToArray();   
            }

            PhotoOfPropert.Photo = fileBytes;

            _context.AddressOfProperties.Add(AddressOfProperty);
            _context.Properties.Add(Property);

            await _context.SaveChangesAsync();

            PhotoOfPropert.Adress = Property.Id;
            _context.PhotoOfProperts.Add(PhotoOfPropert);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }
}
