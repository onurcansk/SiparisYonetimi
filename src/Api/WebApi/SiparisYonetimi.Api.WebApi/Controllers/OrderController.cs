using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiparisYonetimi.Api.WebApi.ActionFilters;
using SiparisYonetimi.Common.Exceptions;
using SiparisYonetimi.Common.Models.RequestModels;

namespace SiparisYonetimi.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidationFilter]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("NewOrder")]
        public async Task<IActionResult> NewOrder([FromBody] CreateOrderCommand command)
        {
            try
            {
                var result = await mediator.Send(command);
                return Ok(result);
            }
            catch (NotInServiceTimeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotAvaibleCompanyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
