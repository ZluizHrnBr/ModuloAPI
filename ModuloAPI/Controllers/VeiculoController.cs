using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Configuration;
using ModuloAPI.DTO;
using ModuloAPI.Entidades;
using ModuloAPI.Services;
using System;
using System.Collections.Generic;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController
    {
        private readonly UsuarioServices _usuarioService;
        private readonly TokenService _tokenService;
        private readonly VeiculoServices _veiculoService;

        public VeiculoController(UsuarioServices usuarioServices, TokenService tokenService, VeiculoServices veiculoServices) 
        {
            _usuarioService = usuarioServices;
            _tokenService = tokenService;
            _veiculoService = veiculoServices;
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

        [HttpPost("CadastrarVeiculo")]
        [Authorize(Roles = "administrador")]
        public Veiculo CadastrarVeiculo([FromBody] VeiculoDTO veiculo)
        {
            return _veiculoService.CadastrarVeiculo(veiculo);
        }

        [HttpDelete("DeletarVeiculo/{Nome_Veiculo}")]
        [Authorize(Roles = "administrador")]
        public int DeletarVeiculo(string Nome_Veiculo)
        {
            return _veiculoService.DeletarVeiculo(Nome_Veiculo);
        }

        [HttpGet("ListarVeiculos")]
        public List<VeiculoDTO> CarregarLista()
        {
            return _veiculoService.ListarVeiculos();
        }

        [HttpPut("AtualizarVeiculo")]
        [Authorize(Roles = "administrador")]
        public Veiculo AtualizarVeiculo([FromBody] VeiculoDTO veiculo)
        {
            try
            {
                return _veiculoService.AtualizarVeiculo(veiculo);
            } catch (Exception e)
            {
                throw new Exception("Falha ao tentar atualizar o veículo." + e);
            }
           
        }
    }
}
