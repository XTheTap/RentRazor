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

        public string GetPictureAdress(int id)
        {
            var tempCollection = rentProperty.PhotoOfProperts.Where(x => x.Adress == id);
            if (!tempCollection.Any())
                return "https://www.publicdomainpictures.net/pictures/280000/velka/not-found-image-15383864787lu.jpg";
            
            return $"~/Api/PhotoControll?id=" + tempCollection.First().Id;
        }
    }
}
