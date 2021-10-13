using System;
using System.Collections.Generic;

#nullable disable

namespace RentRazor.DbModel
{
    public partial class TagsOfProperty
    {
        public TagsOfProperty()
        {
            TagMerges = new HashSet<TagMerge>();
        }

        public int Id { get; set; }
        public string TagName { get; set; }
        public double? Rating { get; set; }

        public virtual ICollection<TagMerge> TagMerges { get; set; }
    }
}
