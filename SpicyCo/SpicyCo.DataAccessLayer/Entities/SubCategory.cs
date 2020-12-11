using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Entities
{
    public class SubCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }        
        public virtual Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public virtual ICollection<Value> Values { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
