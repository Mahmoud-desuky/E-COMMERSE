using Back.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Back.API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController:BaseApiController
    {
        public IActionResult Errors(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}