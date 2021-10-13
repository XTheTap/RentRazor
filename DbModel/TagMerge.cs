using System;
using System.Collections.Generic;

#nullable disable

namespace RentRazor.DbModel
{
    public partial class TagMerge
    {
        public int Id { get; set; }
        public int? IdOfTag { get; set; }
        public int? IdOfProperty { get; set; }

        public virtual Property IdOfPropertyNavigation { get; set; }
        public virtual TagsOfProperty IdOfTagNavigation { get; set; }
    }
}
