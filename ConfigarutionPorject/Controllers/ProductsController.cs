using AutoMapper;
using ConfigarutionPorject.DAL.EFCORE;
using ConfigarutionPorject.Entities;
using ConfigarutionPorject.Entities.DTOs.CagtegoryDtos;
using ConfigarutionPorject.Entities.DTOs.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ConfigarutionPorject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppBackendContext _context;
        IMapper _mapper;
        public ProductsController(AppBackendContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]

        public async Task<ActionResult<GetProductDto>> GetProduct()
        {
            var products = await _context.Products.
                Select(c => new GetProductDto
                {
                    Name = c.Name
                    , Description = c.Description,
                    Price = c.Price,
                    CategoryId = c.CategoryId

                }).ToListAsync();
            ;
            return Ok(products);
        }

        [HttpPost]

        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut]

        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto dto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, product);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]

        public async Task<ActionResult<GetProductDto>> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<GetProductDto>(product);
            return Ok(productDto);
        }

    }
}