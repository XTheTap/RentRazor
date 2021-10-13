using System;
using System.Collections.Generic;

#nullable disable

namespace RentRazor.DbModel
{
    public partial class Property
    {
        public Property()
        {
            PhotoOfProperts = new HashSet<PhotoOfPropert>();
            TagMerges = new HashSet<TagMerge>();
        }

        public int Id { get; set; }
        public int? Adress { get; set; }
        public int? PropertyType { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual AddressOfProperty AdressNavigation { get; set; }
        public virtual PropertyType PropertyTypeNavigation { get; set; }
        public virtual ICollection<PhotoOfPropert> PhotoOfProperts { get; set; }
        public virtual ICollection<TagMerge> TagMerges { get; set; }
    }
}
