using SpicyCo.BusinessLayer.Interfaces;
using SpicyCo.DataAccessLayer.Dtos;
using SpicyCo.DataAccessLayer.Entities;
using SpicyCo.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.BusinessLayer.Managers
{
    public class ProductManager: IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> AddNewProduct(ProductDto productDto, string subcategoryName)
        {
            var newProduct = new Product(subcategoryName)
            {
                Name = productDto.Name,
                Description = productDto.Description,
                IsAvailable = productDto.IsAvailable,
                Quantity = productDto.Quantity,
                Price = productDto.Price
            };

            await _unitOfWork.GetRepository<Product>().Insert(newProduct);
            await _unitOfWork.SaveAsync();

            return await _unitOfWork.GetRepository<Product>().GetAll();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            var product = await _unitOfWork.GetRepository<Product>().GetById(id);
            return product;
        }
    }
}
