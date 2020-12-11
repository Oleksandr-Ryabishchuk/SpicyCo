using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpicyCo.DataAccessLayer.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpicyCo.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        //private readonly ILogger<PremiumController> _logger;
        private readonly IMediator _mediator;
        public PremiumController(//ILogger<PremiumController> logger,
                                 IMediator mediator)
        {
           // _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> BuyPremium()
        {
            var result = (await _mediator.Send(new AddPremiumAccountRequest
            {
                CustomerId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                PremiumType = 2
            })).Cost;
            
            return Ok(result);
        }
    }
}
