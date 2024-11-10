﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaDeTarefas.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : Controller
    {
        [HttpPost]
        public  IActionResult Login([FromBody] LoginModel login)
        {
            if(login.Login == "admin" && login.Senha == "admin")
            {
                var token = GerarTokenJWT();
                return Ok(new {token});
            }
            return BadRequest(new {mensagem = "Credênciais invalidas."});
        }

        private string GerarTokenJWT()
        {
            string chaveSecreta = "46db68fc-03e9-431e-8be0-806f57a7f569";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login","admin"),
                new Claim("nome", "Administrador do Sistema")
            };

            var token = new JwtSecurityToken(
                issuer: "sua_empresa",
                audience: "sua_aplicacao",
                claims: null,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
