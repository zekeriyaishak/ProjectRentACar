using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    IBrandService _brandService;

    public BrandsController(IBrandService brandService, ILogger<BrandsController> logger)
        : base(logger)
    {
        _brandService = brandService;
    }
    [HttpPost("add")]
    public IActionResult Add(Brand brand)
    {
        LogInformation("BrandsController Add method called.");
        var result = _brandService.AddBrand(brand);
        if (result.Success)
        {
            LogInformation($"Brand added successfully: {brand.BrandName}");
            return Ok(result);
        }
        LogError(new Exception(result.Message));
        return BadRequest(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete(Brand brand)
    {
        var result = _brandService.DeleteBrand(brand);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        LogInformation("BrandsController getAll method called.");
        var result = _brandService.GetAll();
        if (result.Success)
        {
            LogInformation($"Brand getall successfully");
            return Ok(result);
        }
        LogError(new Exception(result.Message));
        return BadRequest(result);
    }
    [HttpPatch("update")]
    public IActionResult Update(Brand brand)
    {
        var result = _brandService.UpdateBrand(brand);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getallbybrandId")]
    public IActionResult GetByBrandId(int brandId)
    {
        var result = _brandService.GetAllByBrandsId(brandId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

}

