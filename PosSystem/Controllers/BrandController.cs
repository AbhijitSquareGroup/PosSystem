using Microsoft.AspNetCore.Mvc;
using PosSystem.Models;
using PosSystem.Repository.Abstraction;

namespace PosSystem.Controllers
{
    public class BrandController : Controller
    {
        public IBrandRepository _brandRepository;
        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
            [HttpGet]
            public IActionResult GetBrands(int BrandId)
            {
            var existingBrand = _brandRepository.GetById(BrandId);
            if (existingBrand == null)
            {
                return BadRequest("Invalid BrandId.");
            }

            return Ok(existingBrand);
            }
        [HttpGet]
        public IActionResult GetAllBrands()
        {
            var existingBrand = _brandRepository.GetAll();
            return Ok(existingBrand);
        }
    }
}
