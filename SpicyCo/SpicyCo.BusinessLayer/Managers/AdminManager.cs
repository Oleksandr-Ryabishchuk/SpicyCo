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
    public class AdminManager//: IAdminManager
    {
        //private readonly IUnitOfWork _unitOfWork;
        //public AdminManager(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        //public async Task<IEnumerable<Product>> AddNewProduct(ProductDto productDto)
        //{
        //    var newProduct = new Product
        //    {
        //        Name = productDto.Name,
        //        Description = productDto.Description,
        //        IsAvailable = productDto.IsAvailable,
        //        Quantity = productDto.Quantity,
        //        Price = productDto.Price               
        //    };

        //    await _unitOfWork.GetRepository<Product>().Insert(newProduct);
        //    await _unitOfWork.SaveAsync();

        //    return await _unitOfWork.GetRepository<Product>().GetAll();
        //}
    }
}
