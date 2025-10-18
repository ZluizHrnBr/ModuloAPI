using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Configuration;
using ModuloAPI.DTO;
using ModuloAPI.Entidades;
using ModuloAPI.Services;
using System;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController
    {
        private readonly UsuarioServices _usuarioService;
        private readonly TokenService _tokenService;

        public VeiculoController(UsuarioServices usuarioServices, TokenService tokenService) 
        {
            _usuarioService = usuarioServices;
            _tokenService = tokenService;
        }


        [HttpPost("CadastrarUsuario")]
        public Usuario CadastrarUsuario([FromBody] UserDTO usuario)
        {
            return _usuarioService.CriarUsuario(usuario);
        }

        [HttpGet("LogarUsuario/{NomeUsuario}")]
        public string LogarUsuario(string NomeUsuario)
        {
            try
            {
                var user = _tokenService.createToken(_usuarioService.LogarUsuario(NomeUsuario));

                return user;
            } catch(Exception e){
                throw new Exception("Falha ao gerar token de autenticaçãod de acesso ao usuário " + e);
            }
        
        }
    }
}
