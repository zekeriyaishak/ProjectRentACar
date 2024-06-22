using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarImagesController : BaseController
{
    ICarImageService _carImagesService;

    public CarImagesController(ICarImageService carImagesService, ILogger<CarImagesController> logger)
        :base(logger)
    {
        _carImagesService = carImagesService;
    }
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var result = _carImagesService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getbycarid")]
    public IActionResult GetByCarId(int carId)
    {
        var result = _carImagesService.GetByCarId(carId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("Add")]
    public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
    {
        var result = _carImagesService.Add(file, carImage);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("Update")]
    public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
    {
        var result = _carImagesService.Update(file, carImage);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }


    [HttpPost("Delete")]
    public IActionResult Delete(CarImage carImage)
    {
        var result = _carImagesService.Delete(carImage);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("GetByImageId")]
    public IActionResult GetByImageId(int imageId)
    {
        var result = _carImagesService.GetImageByImageId(imageId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

}
