using SpicyCo.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.BusinessLayer.Interfaces
{
    public interface IJWTGeneration
    {
        Task<string> GenerateJwtToken(User user);
    }
}
