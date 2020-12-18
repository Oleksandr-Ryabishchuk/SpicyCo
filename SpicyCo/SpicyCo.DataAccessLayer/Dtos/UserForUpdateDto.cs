using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Dtos
{
    public class UserForUpdateDto
    {
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
