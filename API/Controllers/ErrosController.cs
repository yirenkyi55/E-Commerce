using API.Error;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            //We need to redirect any not found route to this route(doing by middleware)
            return new ObjectResult(new ApiResponse(code));
        }
    }
}