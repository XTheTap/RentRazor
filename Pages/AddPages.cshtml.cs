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

            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                Photo.CopyTo(ms);
                fileBytes = ms.ToArray();   
            }

            PhotoOfPropert.Adress = Property.Id;
            PhotoOfPropert.Photo = fileBytes;

            _context.PhotoOfProperts.Add(PhotoOfPropert);
            _context.AddressOfProperties.Add(AddressOfProperty);
            _context.Properties.Add(Property);

            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }


    }
}
