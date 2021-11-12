using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.Business.Responses;

namespace WebApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;
        
        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
        
        protected IActionResult Error(ServiceResponse response)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, response);
        }
    }
}