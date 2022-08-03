﻿using IterUpApi.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims;
using System.Text;
 

namespace IterUpApi.Service
{
    public class GerarToken
    {
        public GerarToken()
        {

        }
        public string GenerateJWT(Usuario user)
        {
            //Claim Revidicar Autorização
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)
            };

            var TipoUsuario = "Adm";

            claims.Add(new Claim(ClaimTypes.Role, TipoUsuario));

            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("InterUpaApi")),
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("InterUpaApi Melhor Empresa"));
            var CriptografarKey = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var DescricaoToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = CriptografarKey
            };

            var InstanciarToken = new JwtSecurityTokenHandler();

            var token = InstanciarToken.CreateToken(DescricaoToken);

            return InstanciarToken.WriteToken(token);
        }
    }
}
