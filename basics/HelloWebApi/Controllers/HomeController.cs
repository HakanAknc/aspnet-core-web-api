using HelloWebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace HelloWebApi.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ResponseModel GetMessage()
        {
            return new ResponseModel()
            {
                HttpStatus = 200,
                Message = "Hello ASP.NET Core Web API"
            };
        }
    }
}
