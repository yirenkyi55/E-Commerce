using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Error;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/products")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
                                    IGenericRepository<ProductBrand> productBrandRepo,
                                    IGenericRepository<ProductType> productTypeRepo,
                                    IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var specification = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productRepo.ListAllAsync(specification);
            return Ok(_mapper.Map<IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var specification = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productRepo.GetEntityWithSpecification(specification);

            if (product == null) return NotFound(new ApiResponse(404));

            var productToReturn = _mapper.Map<ProductToReturnDto>(product);

            return Ok(productToReturn);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var brands = await _productBrandRepo.ListAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var types = await _productTypeRepo.ListAllAsync();
            return Ok(types);
        }

    }
}