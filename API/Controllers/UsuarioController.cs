using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using APIAcessoDados.Modelos;
using APIAcessoDados.ModelView;
using APIRegrasNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using APIAcessoDados.ObjetosAcesso;

namespace API.Controllers
{
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        UsuarioBll _usuarioBll = new UsuarioBll();
        ErrorHandler _errorHandler = new ErrorHandler();

        [Route("~/api/Usuario/Adicionar")]
        [HttpPost]
        public IActionResult Adicionar([FromBody] UsuarioModelView usuarioModelView)
        {
            try
            {
                _usuarioBll.Inserir(usuarioModelView);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [Route("~/api/Usuario/Logar")]
        [HttpPost]
        public object Logar(
            [FromBody] UsuarioModelView usuarioModelView,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfiguration tokenConfigurations)
        {
            bool credenciaisValidas = false;

            if (usuarioModelView != null && !String.IsNullOrWhiteSpace(usuarioModelView.UserID))
            {
                var usuarioBase = _usuarioBll.ObterPorId(usuarioModelView.UserID);
                credenciaisValidas = (usuarioBase != null &&
                    usuarioModelView.UserID == usuarioBase.UserID &&
                    usuarioModelView.AccessKey == usuarioBase.AccessKey);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuarioModelView.UserID, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuarioModelView.UserID)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }

            else
            {
                _errorHandler.Mensagem = "Usuário não autorizado!";
                _errorHandler.Error = true;

                return StatusCode(401, Json(_errorHandler));
            }
        }
    }
}