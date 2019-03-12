using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitSample.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IBusControl bus;

        public ValuesController(IBusControl busControl)
        {
            this.bus = busControl;
        }
        // GET api/values/5
        [HttpGet("{message}")]
        public async Task<IActionResult> Get(string message)
        {
            await bus.Publish<Domain.Submit>(new Domain.Submit { Message = message });
            return Ok(message);
        }
    }
}
