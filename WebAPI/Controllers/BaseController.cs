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
        protected IActionResult HandleAction(Func<IActionResult> action, string actionName)
        {
            try
            {
                LogInformation($"{actionName} method called.");
                var result = action();
                if (result is ObjectResult objectResult && (objectResult.StatusCode >= 400))
                {
                    LogError(new Exception(objectResult.Value?.ToString() ?? "Bad Request"));
                }
                else if (result is StatusCodeResult statusCodeResult && statusCodeResult.StatusCode >= 400)
                {
                    LogError(new Exception("Bad Request"));
                }
                else
                {
                    LogInformation($"{actionName} method completed successfully.");
                }
                return result;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        protected ActionResult HandleAction(Func<ActionResult> action, string actionName)
        {
            try
            {
                LogInformation($"{actionName} method called.");
                var result = action();
                if (result is ObjectResult objectResult && (objectResult.StatusCode >= 400))
                {
                    LogError(new Exception(objectResult.Value?.ToString() ?? "Bad Request"));
                }
                else if (result is StatusCodeResult statusCodeResult && statusCodeResult.StatusCode >= 400)
                {
                    LogError(new Exception("Bad Request"));
                }
                else
                {
                    LogInformation($"{actionName} method completed successfully.");
                }
                return result;
            }
            catch (Exception ex)
            {
                LogError(ex);
                return StatusCode(500, "Internal server error");
            }
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
