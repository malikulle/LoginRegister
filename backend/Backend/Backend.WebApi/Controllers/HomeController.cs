using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet(template:"")]
        public IActionResult Get()
        {
            return Ok(new { value= "Values[1,2]" });
        }
    }
}