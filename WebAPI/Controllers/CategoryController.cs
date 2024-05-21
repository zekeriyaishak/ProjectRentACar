using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.AddCategory(category);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryService.DeleteCategory(category);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPatch("update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.UpdateCategory(category);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getallbyCategoryId")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var result = _categoryService.GetAllByCategoriesId(categoryId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
