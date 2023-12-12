using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : BaseController
    {
        IColorService _modelService;

        public ColorsController(IColorService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost("add")]

        public IActionResult Add(Color model)
        {
            var result = _modelService.AddColor(model);
            if(result.Success)
            {
                return Ok (result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]

        public IActionResult Delete(Color model)
        {
            var result = _modelService.DeleteColor(model);
            if(result.Success)
            {
                return Ok (result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _modelService.GetAll();
            if(result.Success)
            {
                return Ok (result);
            }
            return BadRequest(result);
        }

        [HttpPatch("update")]

        public IActionResult Update(Color model)
        { 
            var result = _modelService.UpdateColor(model);
            if(result.Success)
            {
                return Ok (result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbymodelId")]
       
        public IActionResult GetByModelId(int modelId)
        {
            var result = _modelService.GetAllByColorsId(modelId);
            if (result.Success)
            {
                return Ok (result);
            }
            return BadRequest(result);
        }

    }
}
