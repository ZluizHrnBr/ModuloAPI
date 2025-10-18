using System;
using System.Collections.Generic;

namespace ModuloAPI.DTO
{
    public record UserDTO( Guid Id_Usuario ,string NomeUsuario, string Senha, string Email, string role)
    {
    }
}
