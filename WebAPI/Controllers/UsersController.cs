﻿using Business.Abstract;
using CorePackagesGeneral.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    IUserService _userService;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
        :base(logger)
    {
        _userService = userService;
    }
    [HttpPost("add")]
    public IActionResult Add(User user)
    {
        var result = _userService.AddUser(user);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete(User user)
    {
        var result = _userService.DeleteUser(user);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _userService.GetAll();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpPatch("update")]
    public IActionResult Update(User user)
    {
        var result = _userService.UpdateUser(user);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
