using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        protected void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        protected void LogError(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }
}
