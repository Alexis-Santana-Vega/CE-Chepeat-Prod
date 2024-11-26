using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Application.Services;
public interface IJwtService
{
    string GenerarToken(User user);
    string GenerarRefreshToken();
    ClaimsPrincipal ValidarToken(string token);
    string GenerateAccessToken(User user);

}
