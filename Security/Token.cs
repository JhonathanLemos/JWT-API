using Microsoft.AspNetCore.Mvc;

namespace NetCoreAPI.Security
{
    public class Token : ControllerBase
    {
        public Token()
        {

        }
        public IResult GenerateToken()
        {
            return Results.Ok();
        }
    }
}
