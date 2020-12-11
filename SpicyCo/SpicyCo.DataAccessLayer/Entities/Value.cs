using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyCo.DataAccessLayer.Entities
{
    public class Value
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public Guid SubCategoryId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
    }
}
