using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Entities
{
    public class Order
    {
        public Guid Id { get; set; }                
        public string Address { get; set; }
        public DateTime DeliveryDate { get; set; }       
        public virtual User Customer { get; set; }
        public Guid CustomerId { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
