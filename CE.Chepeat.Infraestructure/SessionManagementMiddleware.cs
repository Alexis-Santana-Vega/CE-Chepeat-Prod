using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CE.Chepeat.Application.Services;
using Microsoft.AspNetCore.Http;

namespace CE.Chepeat.Infraestructure;
public class SessionManagementMiddleware
{
    private readonly RequestDelegate _next;

    public SessionManagementMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IJwtService jwtService, IAuthInfraestructure sesionRepository)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrEmpty(token))
        {
            var principal = jwtService.ValidarToken(token);
            /*
            if (principal == null)
            {
                // Token inválido, tratar de refrescarlo
                var refreshToken = context.Request.Headers["RefreshToken"].FirstOrDefault();

                if (!string.IsNullOrEmpty(refreshToken))
                {
                    var sesion = await sesionRepository.ObtenerPorRefreshTokenAsync(refreshToken);

                    if (sesion != null && sesion.ExpiresAt > DateTime.UtcNow)
                    {
                        // Refresh token válido, generar nuevo token
                        var usuarioId = sesion.IdUser;
                        var usuarioRepository = context.RequestServices.GetRequiredService<IAuthInfraestructure>();
                        var usuario = await usuarioRepository.ObtenerPorId(usuarioId);

                        if (usuario != null)
                        {
                            var nuevoToken = jwtService.GenerarToken(usuario);
                            var nuevoRefreshToken = jwtService.GenerarRefreshToken();

                            // Actualizar sesión con el nuevo refresh token
                            sesion.RefreshToken = nuevoRefreshToken;
                            sesion.CreatedAt = DateTime.UtcNow;
                            sesion.ExpiresAt = DateTime.UtcNow.AddDays(20);

                            await sesionRepository.CrearAsync(sesion);

                            // Añadir el nuevo token al encabezado de respuesta
                            context.Response.Headers.Add("Authorization", $"Bearer {nuevoToken}");
                            context.Response.Headers.Add("RefreshToken", nuevoRefreshToken);
                        }
                    }
                    else
                    {
                        // Refresh token inválido o expirado
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Refresh token inválido o expirado.");
                        return;
                    }
                }
                else
                {
                    // No hay refresh token, el token JWT es inválido
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Token expirado o inválido.");
                    return;
                }
            }
            else
            {
                // Token válido, añadir el usuario al contexto
                context.User = principal;
            }
            */
        }

        // Llamar al siguiente middleware en la cadena
        await _next(context);
    }
}
