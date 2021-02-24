using System.Collections.Generic;
using AutoMapper;
using IGS.OnlineMarketplace.Dtos;
using IGS.OnlineMarketplace.Models;
using IGS.OnlineMarketplace.Services;
using Microsoft.AspNetCore.Mvc;

namespace IGS.OnlineMarketplace.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost()]
        public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            _service.CreateProduct(product);
            _service.SaveChanges();

            var productReadDto = _mapper.Map<ProductReadDto>(product);

            return CreatedAtRoute(nameof(GetProductById), new {Id = productReadDto.Id}, productReadDto);
        }

        [HttpGet()]
        public ActionResult <IEnumerable<ProductReadDto>> GetAllProducts()
        {
            var allProducts = _service.GetAllProducts();
            var allProductDtos = _mapper.Map<IEnumerable<ProductReadDto>>(allProducts);

            return Ok(allProductDtos);
        }

        [HttpGet("{id}", Name="GetProductById")]
        public ActionResult <ProductReadDto> GetProductById(int id)
        {
            var product = _service.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }

            var productReadDto = _mapper.Map<ProductReadDto>(product);
            return Ok(productReadDto);
            
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var product = _service.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }

            _mapper.Map(productUpdateDto, product);

            _service.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _service.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }

            _service.DeleteProduct(product);
            _service.SaveChanges();

            return NoContent();
        }

    }
}