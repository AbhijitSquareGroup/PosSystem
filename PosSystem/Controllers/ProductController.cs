using Microsoft.AspNetCore.Mvc;
using PosSystem.Models;
using PosSystem.Models.UtilitiesModels;
using PosSystem.Repository;
using PosSystem.Repository.Abstraction;
using System.Collections.Generic;

namespace PosSystem.Controllers
{
    public class ProductController : Controller
    {
        public IProductRepository _productRepository;
        public IBrandRepository _brandRepository;

        public ProductController(IProductRepository productRepository,IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateGet([FromQuery] string searchKey)
        {
            ICollection<Product> products;

            if (!string.IsNullOrEmpty(searchKey))
            {
                var productSearchCriteria = new ProductSearchCriteria
                {
                    SearchKey = searchKey
                };
                products = _productRepository.SearchProduct(productSearchCriteria);
            }
            else
            {
                products = _productRepository.GetAll();
            }

            return Ok(products);
        }

        
        [HttpPost]
        public IActionResult CreatePost([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data.");
            }
            var existingBrand = _brandRepository.GetById(product.BrandId);
            if (existingBrand == null)
            {
                return BadRequest("Invalid BrandId.");
            }

            bool isSuccess = _productRepository.Add(product);

            if (isSuccess)
            {
                return Ok(new { StatusCode = 200, Message = "Product created successfully." });
               
            }
            else
            {
                return Ok(new { StatusCode = 500, Message = "Failed to create the product." });
                
            }
            
        }
        public IActionResult ProductList()
        {
            ICollection<Product> Products = _productRepository.GetAll();
            return Ok(Products);
        }



        [HttpGet("{ProductId}")]
        public IActionResult GetById(int ProductId)
        {
            var product = _productRepository.GetById(ProductId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        [HttpPut("{ProductId}")]
        public IActionResult Edit(int ProductId, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid product data.");
            }

            var existingProduct = _productRepository.GetById(ProductId);

            if (existingProduct == null)
            {
                return NotFound();
            }

            // Update existingProduct properties with data from the 'product' parameter
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            // Update other properties as needed

            bool isSuccess = _productRepository.Update(existingProduct);

            if (isSuccess)
            {
                return Ok(new { Message = "Product updated successfully." });
            }
            else
            {
                return StatusCode(500, new { Message = "Failed to update the product." });
            }
        }


    }
}



