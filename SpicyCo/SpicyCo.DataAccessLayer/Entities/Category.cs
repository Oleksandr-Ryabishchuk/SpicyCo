using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
