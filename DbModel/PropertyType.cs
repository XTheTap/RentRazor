using System;
using System.Collections.Generic;

#nullable disable

namespace RentRazor.DbModel
{
    public partial class PropertyType
    {
        public PropertyType()
        {
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
