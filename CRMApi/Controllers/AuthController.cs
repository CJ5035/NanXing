using CRMApi.Entity;
using CRMApi.Interface;
using CRMApi.Service;
using CRMApi.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace CRMApi.Controllers
{
    /// <summary>
    /// 认证接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseService _baseService;
        private readonly LoginService _loginService;

        //private readonly ILoginService _loginService;

        //private readonly UserTokenContext _context;
        public AuthController(IConfiguration configuration, IBaseService baseService,
            LoginService loginService)
        {
            _configuration = configuration;
            _baseService = baseService;
            _loginService = loginService;

            //_loginService = loginService;
            //_context = context;
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name="request">认证token凭证</param>
        /// <returns>token</returns>
        [AllowAnonymous]
        [HttpPost]
        [ApiExplorerSettings(GroupName= "v1")]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            string username = request.Username;
            string password = request.Password;
            List<string> powers = new List<string>();
            bool isAdmin= _loginService.DoLogin(username,password,ref powers);

            if (isAdmin)
            {
                // push the user’s name into a claim, so we can identify the user later on.
                var claims = new[]
                {
                   new Claim(ClaimTypes.Name, request.Username)
               };
                //sign the token using a secret key.This secret will be shared between your API and anything that needs to check that the token is legit.
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //.NET Core’s JwtSecurityToken class takes on the heavy lifting and actually creates the token.
                /**
                 * Claims (Payload)
                    Claims 部分包含了一些跟这个 token 有关的重要信息。 JWT 标准规定了一些字段，下面节选一些字段:
                    iss: The issuer of the token，token 是给谁的
                    sub: The subject of the token，token 主题
                    exp: Expiration Time。 token 过期时间，Unix 时间戳格式
                    iat: Issued At。 token 创建时间， Unix 时间戳格式
                    jti: JWT ID。针对当前 token 的唯一标识
                    除了规定的字段外，可以包含其他任何 JSON 兼容的字段。
                 * */
                var token = new JwtSecurityToken(
                    issuer: "CRM",
                    audience: "CRM",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

                var response = new
                {

                    username = username,
                    access_token ="Bearer "+ accessToken,
                    expires_in = 1800
                };

                return Ok(response);

                //return Ok(new
                //{
                //    token = new JwtSecurityTokenHandler().WriteToken(token)
                //});
            }
            else
            {
                return BadRequest("Could not verify username and password");
            }

        }

    }
    /// <summary>
    /// 认证token凭证
    /// </summary>
    public class TokenRequest
    {
        /// <summary>
        /// 认证用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 认证密码
        /// </summary>
        public string Password { get; set; }
    }
    
}
