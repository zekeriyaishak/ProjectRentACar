using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CreditCardsController : BaseController
{
    ICreditCardService _creditCardService;

    public CreditCardsController(ICreditCardService creditCardService)
    {
        _creditCardService = creditCardService;
    }
    [HttpPost("add")]
    public IActionResult Add(CreditCard creditCard)
    {
        var result = _creditCardService.Add(creditCard);
        if(result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete(CreditCard creditCard)
    {
        var result = _creditCardService.Delete(creditCard);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    [HttpPut("update")]
    public IActionResult Update(CreditCard creditCard)
    {
        var result = _creditCardService.Update(creditCard);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        var result = _creditCardService.GetAll();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    [HttpGet("getByCarId")]
    public IActionResult GetByCarId(int carId)
    {
        var result = _creditCardService.GetByCarId(carId);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
}
