using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpicyCo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /*private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();

            var result = await _mediator.Send(query);

            return Ok(result); 
        }*/
    }
}
