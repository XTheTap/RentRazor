using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentRazor.DbModel;
using System.Collections.Generic;
using System.Linq;

namespace RentRazor.Pages
{
    public class RentCardModel : PageModel
    {
        public Property property { get; set; }
        public AddressOfProperty address { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string type { get; set; }
        public int? IdOfPhoto { get; set; }

        private readonly RentPropertyContext rentProperty;

        public RentCardModel(RentPropertyContext rentProperty)
        { 
            this.rentProperty = rentProperty;
        }

        public void OnGet(int id)
        {
            property = rentProperty.Properties.Find(id);
            address = rentProperty.AddressOfProperties.Find(property.Adress);
            type = rentProperty.PropertyTypes.Find(property.PropertyType).Adress;


            List<string> tags = new List<string>();

            foreach(var tagmerge in rentProperty.TagMerges.Where(x => x.IdOfProperty == id))
            {
                tags.Add(rentProperty.TagsOfProperties.Find(tagmerge.IdOfTag).TagName);
            }

            Tags = tags.ToArray();
        }
    }
}