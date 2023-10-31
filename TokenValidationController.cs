using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetCoreAPI;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class TokenValidationController : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public IActionResult ValidateToken([FromBody] TokenRequest request)
    {
        // Aqui você pode verificar se o token expirou
        bool isTokenExpired = IsTokenExpired(request.Token);

        if (isTokenExpired)
        {
            return BadRequest(new { message = "Token has expired." });
        }

        return Ok(new { message = "Token is valid." });
    }

    private bool IsTokenExpired(string token)
    {
        try
        {
            // Faça a validação da data de expiração do token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ASxLbASD@asd13asdLJSc2asd");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };

            SecurityToken validatedToken;
            tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

            // Verifique a data de expiração
            if (validatedToken.ValidTo >= DateTime.UtcNow)
            {
                return false; // Token ainda é válido
            }
            return true; // Token expirado
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return true; // Erro na validação (token inválido)
        }
    }
}
