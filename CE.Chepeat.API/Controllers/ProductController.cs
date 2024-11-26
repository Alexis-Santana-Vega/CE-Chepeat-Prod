using CE.Chepeat.Domain.Aggregates.Product;
using Microsoft.AspNetCore.Authorization;

namespace CE.Chepeat.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ApiController
{
    public ProductController(IApiController appController) : base(appController)
    {

    }

    [HttpPost("GetProductDetails")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [Authorize]
    public async ValueTask<IActionResult> GetProductDetails([FromBody] Guid id)
    {
        return Ok(await _appController.ProductPresenter.GetProductDetails(id));
    }

    [HttpPost("GetProducts")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = "SELLER")]
    public async ValueTask<IActionResult> GetProducts()
    {
        return Ok(await _appController.ProductPresenter.GetProducts());
    }

    [HttpPost("AddProduct")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = "SELLER")]
    public async ValueTask<IActionResult> AddProduct([FromBody] ProductRequest request)
    {
        return Ok(await _appController.ProductPresenter.AddProduct(request));
    }

    [HttpPost("DeleteProduct")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = "SELLER")]
    public async ValueTask<IActionResult> DeleteProduct([FromBody] Guid id)
    {
        return Ok(await _appController.ProductPresenter.DeleteProduct(id));
    }

    [HttpPost("UpdateProduct")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = "SELLER")]
    public async ValueTask<IActionResult> UpdateProduct([FromBody] ProductRequest request)
    {
        return Ok(await _appController.ProductPresenter.UpdateProduct(request));
    }

    [HttpPost("GetProductById")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [Authorize]
    public async ValueTask<IActionResult> GetProductById([FromBody] Guid id)
    {
        return Ok(await _appController.ProductPresenter.GetProductById(id));
    }

    [HttpPost("GetProductsByIdSeller")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [Authorize]
    public async ValueTask<IActionResult> GetProductsByIdSeller([FromBody] Guid id)
    {
        return Ok(await _appController.ProductPresenter.GetProductsByIdSeller(id));
    }

    [HttpPost("GetProductsByRadius")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [Authorize]
    public async ValueTask<IActionResult> GetProductsByRadius([FromBody] ProductRadiusRequest request)
    {
        return Ok(await _appController.ProductPresenter.GetProductsByRadius(request));
    }
}
