using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RentRazor.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentRazor.Pages
{
    public class IndexModel : PageModel
    {
        public readonly RentPropertyContext rentProperty;

        public IndexModel(RentPropertyContext rentProperty)
        {
            this.rentProperty = rentProperty;
        }

        public async Task<IActionResult> OnPostSearch(string searcher)
        {
            return Page();
        }
    }
}
