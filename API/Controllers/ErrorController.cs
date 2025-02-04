using Back.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Back.API.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController:BaseApiController
    {
        [HttpGet]
        public IActionResult Errors(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}