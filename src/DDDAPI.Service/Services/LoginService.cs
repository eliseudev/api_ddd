using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using DDDAPI.Data.Repository;
using DDDAPI.Domain.Dtos.Login;
using DDDAPI.Domain.Entities;
using DDDAPI.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DDDAPI.Service.Services
{
    public class LoginService 
    {
        private readonly LoginRepository<UsuarioAPIEntity> _repository;
        private readonly SigningConfiguration _signingConfiguration;
        private readonly TokenConfiguration _tokenConfiguration;

        public LoginService(LoginRepository<UsuarioAPIEntity> repository, 
                            SigningConfiguration signingConfiguration,
                            TokenConfiguration tokenConfiguration)
        {
            _repository = repository;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        public async Task<object> GetToken(LoginDto login)
        {
            if (login == null || string.IsNullOrEmpty(login.CNPJ))
            {
                return new {
                    authencicated = false,
                    message = "O CNPJ não foi informado"
                };
            }

            var usuario = await _repository.GetByCNPJ(login.CNPJ);

            if (usuario == null)
            {
                return new {
                    authencicated = false,
                    message = "O usuário correspondente ao CNPJ não foi encontrado"
                };
            }
            else
            {
                ClaimsIdentity identity = new(
                    new GenericIdentity(usuario.CNPJ),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //Jti é o ID do token
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.CNPJ)
                    }
                );

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();

                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SuccessObject(createDate, expirationDate, token, login);
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate,
                                   JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private static object SuccessObject(DateTime createDate, DateTime expirationDate, string token,
                                     LoginDto login)
        {
            return new 
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                login.CNPJ,
                message = "Token de acesso gerado com sucesso"
            };
        }
    }
}
