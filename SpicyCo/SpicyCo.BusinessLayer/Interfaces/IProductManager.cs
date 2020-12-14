using SpicyCo.DataAccessLayer.Dtos;
using SpicyCo.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.BusinessLayer.Interfaces
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> AddNewProduct(ProductDto productDto, string subcategoryName);
        Task<Product> GetProduct(Guid id);

        Task<List<Product>>  GetAllProducts();
    }
}
