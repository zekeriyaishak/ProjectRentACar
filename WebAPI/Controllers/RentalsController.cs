﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : BaseController
{
    IRentalService _rentalService;

    public RentalsController(IRentalService rentalService, ILogger<RentalsController> logger)
        :base(logger)
    {
        _rentalService = rentalService;
    }
    [HttpPost("add")]
    public IActionResult Add(Rental rental)
    {
        var result = _rentalService.AddRental(rental);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete(Rental rental)
    {
        var result = _rentalService.DeleteRental(rental);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _rentalService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpPatch("update")]
    public IActionResult Update(Rental rental)
    {
        var result = _rentalService.UpdateRental(rental);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("getrentaldetails")]
    public IActionResult GetRentalDetails()
    {
        var result = _rentalService.GetRentalDetails();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("getrentalbyid")]
    public IActionResult GetRentalById(int rentalId)
    {
        var result = _rentalService.GetById(rentalId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);

    }

    [HttpGet("iscaravaible")]
    public IActionResult IsCarAvaible(int cardId)
    {
        var result = _rentalService.IsCarAvaible(cardId);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
