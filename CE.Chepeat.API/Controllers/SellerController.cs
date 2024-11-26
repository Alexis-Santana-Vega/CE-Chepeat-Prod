using CE.Chepeat.Domain.Aggregates.Seller;
using Microsoft.AspNetCore.Authorization;

namespace CE.Chepeat.API.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SellerController : ApiController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="appController"></param>
    public SellerController(IApiController appController) : base(appController)
    {

    }

    /// <summary>
    /// Agrega un regsitro a la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("AddUSeller")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> AddSeller([FromBody] SellerRequest sellerRequest)
    {
        /*
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "IdUser");
        if (userIdClaim == null)
        {
            return Unauthorized("User ID not found in the token.");
        }
        if (Guid.TryParse(userIdClaim.Value, out Guid userId))
        {
            sellerRequest.IdUser = userId;
            Console.WriteLine(userId);
        }
        */
        return Ok(await _appController.SellerPresenter.AddSeller(sellerRequest));
    }

    /// <summary>
    /// Agrega un regsitro a la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("UpdateSeller")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> UpdateSeller([FromBody] SellerRequest sellerRequest)
    {
        /*
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "IdUser");
        if (userIdClaim == null)
        {
            return Unauthorized("User ID not found in the token.");
        }
        if (Guid.TryParse(userIdClaim.Value, out Guid userId))
        {
            sellerRequest.IdUser = userId;
            Console.WriteLine(userId);
        }
        */
        return Ok(await _appController.SellerPresenter.UpdateSeller(sellerRequest));
    }

    /// <summary>
    /// Agrega un regsitro a la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("SelectSellerById")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> SelectSellerById([FromBody] Guid id)
    {
        /*
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "IdUser");
        if (userIdClaim == null)
        {
            return Unauthorized("User ID not found in the token.");
        }
        if (Guid.TryParse(userIdClaim.Value, out Guid userId))
        {
            sellerRequest.IdUser = userId;
            Console.WriteLine(userId);
        }
        */
        return Ok(await _appController.SellerPresenter.SelectSellerById(id));
    }

    /// <summary>
    /// Agrega un regsitro a la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("SelectSellersByRadius")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> SelectSellersByRadius([FromBody] SellerRadiusRequest request)
    {
        /*
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "IdUser");
        if (userIdClaim == null)
        {
            return Unauthorized("User ID not found in the token.");
        }
        if (Guid.TryParse(userIdClaim.Value, out Guid userId))
        {
            sellerRequest.IdUser = userId;
            Console.WriteLine(userId);
        }
        */
        return Ok(await _appController.SellerPresenter.SelectSellersByRadius(request));
    }


    /// <summary>
    /// Agrega un regsitro a la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("DeleteSeller")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> DeleteSeller([FromBody] Guid id)
    {
        /*
        var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "IdUser");
        if (userIdClaim == null)
        {
            return Unauthorized("User ID not found in the token.");
        }
        if (Guid.TryParse(userIdClaim.Value, out Guid userId))
        {
            sellerRequest.IdUser = userId;
            Console.WriteLine(userId);
        }
        */
        return Ok(await _appController.SellerPresenter.DeleteSeller(id));
    }

    [HttpPost("SelectSellerByIdUser")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> SelectSellerByIdUser([FromBody] Guid idUser)
    {
        return Ok(await _appController.SellerPresenter.SelectSellerByIdUser(idUser));
    }

    [HttpPost("GetSellerDetails")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> GetSellerDetails([FromBody] Guid id)
    {
        return Ok(await _appController.SellerPresenter.GetSellerDetails(id));
    }

}
