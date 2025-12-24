using AutoMapper;
using ConfigarutionPorject.DAL.EFCORE;
using ConfigarutionPorject.Entities;
using ConfigarutionPorject.Entities.DTOs.CagtegoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ConfigarutionPorject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        
        private readonly AppBackendContext _context;

        IMapper _mapper;
        public CategoriesController(AppBackendContext context,
        IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]

        public async Task<ActionResult<GetCategoryDto>> GetCategories()
        {
            var categories = await _context.Categorys.Select(c=>new GetCategoryDto { 
            Name=c.Name
            }).ToListAsync();
           
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto )
        {
           var category = _mapper.Map<Category>(dto);
            _context.Categorys.Add(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(int id, CreateCategoryDto dto)
        {
            var category = await _context.Categorys.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<GetCategoryDto>> GetCategoryId(int id)
        {
            var category = await _context.Categorys.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound(new
                {
                    status = HttpStatusCode.NotFound,
                    message = "Category not found"
                });
            }

            var categoryDto = _mapper.Map<GetCategoryDto>(category);

            return Ok(categoryDto);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categorys.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categorys.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}
