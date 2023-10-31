using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NetCoreAPI.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(Login login)
        {
            User user = new User() { UserName = login.UserName };
            var result = await _userManager.CreateAsync(user, login.Password);
            if (result.Succeeded)
                return Ok(result);
            else
            {
                return BadRequest(result.TranslateErrors());
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IResult> Login(Login login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null)
                return Results.BadRequest();

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded)
                return Results.BadRequest();

            var key = Encoding.ASCII.GetBytes(_configuration["JwtBearerTokenSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials =
               new SigningCredentials(
                   new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["JwtBearerTokenSettings:Audience"],
                Issuer = _configuration["JwtBearerTokenSettings:Issuer"],
                Expires = DateTime.UtcNow.AddMinutes(2)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Results.Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });

        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        //public async Task GenerateCodeToValidateUser(UserDto user)
        //{
        //    Random random = new Random();
        //    int randomNumber = random.Next(100000, 999999);
        //    string randomCode = randomNumber.ToString("D6");

        //    var emailCodeDto = new EmailCodeDto() { Code = randomCode, UserId = user.Id };
        //    var emailCode = _objectMapper.Map<EmailCode>(emailCodeDto);
        //    await _emailCodeRepository.InsertAsync(emailCode);
        //    await _identidadeService.SendEmailAsync(user, randomCode, Properties.Resources.SubjectEmail, Properties.Resources.bodyEmailCode);

        //}
    }
}
