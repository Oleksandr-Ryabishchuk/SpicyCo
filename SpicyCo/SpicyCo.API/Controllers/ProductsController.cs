﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpicyCo.BusinessLayer.Interfaces;
using SpicyCo.DataAccessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpicyCo.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> AddProduct(ProductDto dto, string subcategoryName)
        {
           var result = await _productManager.AddNewProduct(dto, subcategoryName);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productManager.GetAllProducts();
            return Ok(products);
        }    

        [HttpGet]
        [Route("getProdWithAttr")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productManager.GetProduct(id);
            return Ok(product);
        }
    }
}
