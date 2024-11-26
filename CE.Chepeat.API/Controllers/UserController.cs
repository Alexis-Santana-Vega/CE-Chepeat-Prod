using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
/// Developer : Alexis Eduardo Santana Vega
/// Creation Date : 25/09/2024
/// Creation Description : Controller
/// Update Date : 30/09/2024
/// Update Description : Desarrollo de la plantilla base
/// CopyRight : CE-Chepeat
namespace CE.Chepeat.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ApiController
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="appController"></param>
    public UserController(IApiController appController) : base(appController)
    {

    }

    /// <summary>
    /// Consulta un regsitro de la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// Sample request: 
    /// 
    ///     POST 
    ///       {
    ///         "User":"SysAdmin"
    ///       }
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpGet("GetUsers")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = "BUYER")]
    public async ValueTask<IActionResult> GetUsers()
    {
        return Ok(await _appController.UserPresenter.GetUsers());
    }

    /// <summary>
    /// Agrega un regsitro a la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// Sample request: 
    /// 
    ///     POST 
    ///       {
    ///         "nombre":"Joel",
    ///         "apellidoPaterno":"Lopez",
    ///         "apellidoMaterno":"Martinez",
    ///         "edad":25
    ///       }
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("AddUser")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> AddUser([FromBody] UserAggregate userAggregate)
    {
        return Ok(await _appController.UserPresenter.AddUser(userAggregate));
    }

    /// <summary>
    /// Agrega un regsitro a la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// Sample request: 
    /// 
    ///     POST 
    ///       {
    ///         "nombre":"Joel",
    ///         "apellidoPaterno":"Lopez",
    ///         "apellidoMaterno":"Martinez",
    ///         "edad":25
    ///       }
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpDelete("DeleteUser")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [Authorize(Policy = "SELLER")]
    public async ValueTask<IActionResult> DeleteUser([FromBody] Guid id)
    {
        return Ok(await _appController.UserPresenter.DeleteUser(id));
    }

    /// <summary>
    /// Agrega un regsitro a la tabla GI_Persona
    /// </summary>
    /// <param name="">Params de entrada</param> 
    /// <remarks>
    /// Sample request: 
    /// 
    ///     POST 
    ///       {
    ///         "nombre":"Joel",
    ///         "apellidoPaterno":"Lopez",
    ///         "apellidoMaterno":"Martinez",
    ///         "edad":25
    ///       }
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPatch("UpdateUser")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> UpdateUser([FromBody] UserAggregate userAggregate)
    {
        return Ok(await _appController.UserPresenter.UpdateUser(userAggregate));
    }

}