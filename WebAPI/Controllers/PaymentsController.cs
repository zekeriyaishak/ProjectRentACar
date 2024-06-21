using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : BaseController
{
    IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    [HttpPost("add")]
    public IActionResult Add(Payment payment)
    {
        var result = _paymentService.Add(payment);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete(Payment payment)
    {
        var result = _paymentService.Delete(payment);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    [HttpPut("update")]
    public IActionResult Update(Payment payment)
    {
        var result = _paymentService.Update(payment);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    [HttpGet("getAll")]
    public IActionResult GetAll()
    {
        var result = _paymentService.GetAll();
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
    [HttpGet("getByPaymentId")]
    public IActionResult GetByCarId(int paymentId)
    {
        var result = _paymentService.GetByPaymentId(paymentId);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
}
