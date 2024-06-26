﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseController
    {
        INewsService _newsService;

        public NewsController(INewsService newsService, ILogger<NewsController> logger)
            :base(logger)
        {
            _newsService = newsService;
        }
        [HttpPost("add")]
        public IActionResult Add(News news)
        {
            var result = _newsService.AddNews(news);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(News news)
        {
            var result = _newsService.DeleteNews(news);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _newsService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPatch("update")]
        public IActionResult Update(News news)
        {
            var result = _newsService.UpdateNews(news);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getallbynewsId")]
        public IActionResult GetByNewsId(int newsId)
        {
            var result = _newsService.GetAllByNewsId(newsId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
