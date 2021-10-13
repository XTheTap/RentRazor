using System;
using System.Collections.Generic;

#nullable disable

namespace RentRazor.DbModel
{
    public partial class PhotoOfPropert
    {
        public int Id { get; set; }
        public int? Adress { get; set; }
        public byte[] Photo { get; set; }

        public virtual Property AdressNavigation { get; set; }
    }
}
