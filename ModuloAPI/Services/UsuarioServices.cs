using Microsoft.AspNetCore.Identity;
using ModuloAPI.Context;
using ModuloAPI.DTO;
using ModuloAPI.Entidades;
using ModuloAPI.Interfaces;
using System;
using System.Linq;

namespace ModuloAPI.Services
{
    public class UsuarioServices : IUsuarioRepository
    {

        private readonly DataBaseContext _context;
        public UsuarioServices(DataBaseContext context) 
        {
            _context = context;
        }    
        public Usuario CriarUsuario(UserDTO usuario)
        {
            try
            {
                PasswordHasher<Usuario> _passwordHash = new PasswordHasher<Usuario>();

                Usuario usuarioContext = new Usuario()
                {
                    Id_Usuario = usuario.Id_Usuario,
                    NomeUsuario = usuario.NomeUsuario,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    Role = usuario.role
                };

                usuarioContext.Senha = _passwordHash.HashPassword(usuarioContext, usuario.Senha);

                _context.Usuarios.Add(usuarioContext);
                _context.SaveChanges();
                
                return usuarioContext;

            }
            catch(Exception e)
            {
                throw new Exception("Erro ao cadastrar o usuário " + e);
            }
        }

        public void DeletarUsuario(string Id_Usuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario LogarUsuario(string NomeUsuario)
        {
            try
            {
                var usuario = _context.Usuarios
                .FirstOrDefault(u => u.NomeUsuario.Equals(NomeUsuario));

                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception("Falha ao tentar autenticar o usuário." + e);
            }
            
        }
    }
}
