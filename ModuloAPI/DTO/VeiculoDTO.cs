using System;

namespace ModuloAPI.DTO
{
    public record VeiculoDTO(Guid Id_Veiculo, string Nome_Veiculo, string Marca_veiculo, int Ano_Veiculo)
    {
    }
}
