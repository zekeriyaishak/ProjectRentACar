﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    [HttpPost("add")]
    public IActionResult Add(Brand brand)
    {
        var result = _brandService.AddBrand(brand);
        if (result.Success)
        {
            return Ok(result);
        }
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
        var result = _brandService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
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

