using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Entities
{
    public class Product
    {
        public Product()
        {

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public virtual SubCategory SubCategory { get; private set; }
        public Guid SubCategoryId { get; set; }
        public virtual ICollection<Value> Values { get; private set; }
        public virtual ICollection<Field> Fields { get; private set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Product(string subcategoryName)
        {
            SubCategory = (SubCategory)Category.SubCategories.Where(x => x.Name == subcategoryName);
            Values = SubCategory.Values;           
        }
    }
}
