using ArchitectureTools.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlassProducts.Api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public ActionResult BuildResponse<T>(ActionResponse<T> response) =>
            StatusCode(response.StatusNumber, response);
    }
}
