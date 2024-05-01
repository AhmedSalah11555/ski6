using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase

    {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IGenericRepository<ProductType> productTypeRepo;

        public ProductsController(IGenericRepository<Product> productRepo ,
        IGenericRepository<ProductBrand> productBrandRepo ,
        IGenericRepository<ProductType> productTypeRepo)
        {
            this.productRepo = productRepo;
            this.productBrandRepo = productBrandRepo;
            this.productTypeRepo = productTypeRepo;
        }

        [HttpGet]
    public  async Task <ActionResult<List<Product>>>GetProducts()
    {
        var products= await productRepo.ListAllAsync();
        return Ok(products);

    }
    [HttpGet("{id}")]
    public  async Task <ActionResult<Product>>GetProduct(int id)
    {
         return await productRepo.GetByIdAsync(id);
       

    }
    [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await productTypeRepo.ListAllAsync()); 
    
    }
        
    }
    }
