using ModuloAPI.DTO;
using ModuloAPI.Entidades;

namespace ModuloAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario CriarUsuario(UserDTO usuario);

        public Usuario LogarUsuario(string NomeUsuario);

        public void DeletarUsuario(string Id_Usuario);
    }
}
