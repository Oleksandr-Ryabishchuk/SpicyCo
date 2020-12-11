using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Entities
{
    public class Field
    {
        public Guid Id { get; set; }
        public string Sense { get; set; }
        public virtual Value Value { get; set; }
        public Guid ValueId { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
