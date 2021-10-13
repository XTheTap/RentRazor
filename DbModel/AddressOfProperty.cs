using System;
using System.Collections.Generic;

#nullable disable

namespace RentRazor.DbModel
{
    public partial class AddressOfProperty
    {
        public AddressOfProperty()
        {
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }
        public string Adress { get; set; }
        public int? FloorNumber { get; set; }
        public int? ApartmentNumber { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
