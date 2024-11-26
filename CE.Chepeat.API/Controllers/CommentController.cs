using CE.Chepeat.Domain.Aggregates.Comments;
using CE.Chepeat.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CE.Chepeat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ApiController
    {
        public CommentController(IApiController appController) : base(appController)
        {
        }

        /// <summary>
        /// Agrega un nuevo comentario para un vendedor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///         "idUser": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "idSeller": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "idTransaction": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "message": "Excelente servicio",
        ///         "rating": 4.5
        ///     }
        /// </remarks>
        /// <response code="200">Operación exitosa</response>
        /// <response code="400">Datos inválidos</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPost("AddComment")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(RespuestaDB), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async ValueTask<IActionResult> AddComment([FromBody] CommentAggregate commentAggregate)
        {
            return Ok(await _appController.CommentPresenter.AddComment(commentAggregate));
        }

        /// <summary>
        /// Actualiza el mensaje de un comentario existente
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT
        ///     {
        ///         "commentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "idUser": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "newMessage": "Actualización del comentario"
        ///     }
        /// </remarks>
        [HttpPost("UpdateComment")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(RespuestaDB), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async ValueTask<IActionResult> UpdateComment([FromBody] UpdateCommentMessageAggregate updateMessage)
        {
            return Ok(await _appController.CommentPresenter.UpdateCommentMessage(updateMessage));
        }


        [HttpPost("GetCommentById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(RespuestaDB), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async ValueTask<IActionResult> GetCommentById([FromBody] Guid id)
        {
            return Ok(await _appController.CommentPresenter.GetCommentById(id));
        }

    }
}