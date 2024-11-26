using CE.Chepeat.Domain.Aggregates.Transaction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CE.Chepeat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ApiController
    {
        public TransactionController(IApiController appController) : base(appController)
        {
        }

        [HttpPost("AddTransaction")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> AddTransaction([FromBody] TransactionRequest transactionAggregate)
        {
            return Ok(await _appController.TransactionPresenter.AddTransaction(transactionAggregate));
        }

        [HttpPost("GetTransactionStatus")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetTransactionStatus([FromBody] Guid idTransaction)
        {
            return Ok(await _appController.TransactionPresenter.GetTransactionStatus(idTransaction));
        }

        [HttpPost("CompleteTransaction")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> CompleteTransaction([FromBody] TransactionCompleteRequest request)
        {
            return Ok(await _appController.TransactionPresenter.CompleteTransaction(request));
        }

        [HttpPost("ViewBySeller")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> ViewBySeller([FromBody] Guid id)
        {
            return Ok(await _appController.TransactionPresenter.GetTransactionsBySeller(id));
        }

        [HttpPost("ViewByBuyer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> ViewByBuyer([FromBody] Guid id)
        {
            return Ok(await _appController.TransactionPresenter.GetTransactionsByBuyer(id));
        }
    }
}
