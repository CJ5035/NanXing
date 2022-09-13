using Microsoft.IdentityModel.Tokens;
using NanXingData_WMS.Dao;
using NanXingService_WMS.Utils.RedisUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using WebApi_Aps.Utils;

namespace WebApi_Aps.Controllers
{
    [RoutePrefix("api")]
    public class AuthController : BaseController
    {
        RedisHelper redisHelper = new RedisHelper();

        public AuthController()
        {
            CallContextUtils.SetContext();
            Console.WriteLine("SetContext");
        }

        [WebMethod]
        [AllowAnonymous]
        [HttpPost]
        [Route("Auth")]
        public object RequestToken([FromBody] TokenRequest request)
        {
            if(request==null)
                return BadRequest("Could not verify username and password");
            string username = request.Username;
            string password = request.Password;
            List<string> powers = new List<string>();
            bool isAdmin = UserService.DoLogin(username, password, ref powers);
            if (isAdmin)
            {
                Users user= UserService.GetByName(username);
                string redis_Key = request.IsWeiXin ? $"wxkey:{username}" : $"key:{username}";
                string redis_token = redisHelper.StringGet(redis_Key);
                //检查Redis，如果有数据返回Redis的Token
                if (!string.IsNullOrEmpty(redis_token))
                {
                    var response = new
                    {
                        username = username + ":" + user.ChineseName,
                        access_token = redis_token,
                        expires_in = redisHelper.GetKeyExpSecond(redis_Key)
                    };
                    return Ok(response);
                }
                else
                {
                    // push the user’s name into a claim, so we can identify the user later on.
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, request.Username)
                    };
                    //sign the token using a secret key.This secret will be shared between your API and anything that needs to check that the token is legit.
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["SecurityKey"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    DateTime dtTime = DateTime.Now.AddMinutes(30);
                    if (request.IsWeiXin)
                        dtTime = DateTime.Now.AddDays(1);
                    var token = new JwtSecurityToken(
                       issuer: "CRM",
                       audience: "CRM",
                       claims: claims,
                       expires: dtTime,
                       signingCredentials: creds);

                    var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    var response = new
                    {
                        username = username+":"+ user.ChineseName,
                        access_token = "Bearer " + accessToken,
                        expires_in = request.IsWeiXin ? 86400 : 1800
                    };
                    redisHelper.StringSet(redis_Key, response.access_token, dtTime);
                    return Ok(response);
                }
            }
            else
            {
                return BadRequest("Could not verify username and password");
            }
        }

        [WebMethod]
        [AllowAnonymous]
        [HttpPost]
        [Route("Auth/TokenTimeOut")]
        public async Task<object> RequestTokenTimeOut([FromBody] TokenRequest request)
        {
            if (request == null)
                return BadRequest("Could not verify username and password");
            string username = request.Username;
            string password = request.Password;
            List<string> powers = new List<string>();
            
            Task task = Task.Run(() => { Thread.Sleep(10000); });
            await task;
            bool isAdmin = UserService.DoLogin(username, password, ref powers);
            if (isAdmin)
            {
                string redis_Key = request.IsWeiXin? $"wxkey:{username}": $"key:{username}";
                string redis_token = redisHelper.StringGet(redis_Key);
                //检查Redis，如果有数据返回Redis的Token
                if (!string.IsNullOrEmpty(redis_token))
                {
                    var response = new
                    {
                        username = username,
                        access_token = redis_token,
                        expires_in = redisHelper.GetKeyExpSecond(redis_Key)
                    };
                    return Ok(response);
                }
                else
                {
                    // push the user’s name into a claim, so we can identify the user later on.
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, request.Username)
                    };
                    //sign the token using a secret key.This secret will be shared between your API and anything that needs to check that the token is legit.
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["SecurityKey"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    DateTime dtTime = DateTime.Now.AddMinutes(30);
                    if (request.IsWeiXin)
                        dtTime = DateTime.Now.AddDays(1);
                    var token = new JwtSecurityToken(
                       issuer: "CRM",
                       audience: "CRM",
                       claims: claims,
                       expires: dtTime,
                       signingCredentials: creds);

                    var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    var response = new
                    {
                        username = username,
                        access_token = "Bearer " + accessToken,
                        expires_in = request.IsWeiXin ? 86400 : 1800
                    };
                    redisHelper.StringSet(redis_Key, response.access_token, dtTime);
                   
                    return Ok(response);
                }
            }
            else
            {
                return BadRequest("Could not verify username and password");
            }
        }

        /// <summary>
        /// 认证token凭证
        /// </summary>
        public class TokenRequest
        {
            public TokenRequest(string username, string password, bool isweixin)
            {
                Username = username;
                Password = password;
                IsWeiXin = isweixin;
            }

            /// <summary>
            /// 认证用户名
            /// </summary>
            public string Username { get; set; }
            /// <summary>
            /// 认证密码
            /// </summary>
            public string Password { get; set; }

            public bool IsWeiXin { get; set; }
        }
    }
}
