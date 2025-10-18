using ModuloAPI.DTO;
using ModuloAPI.Entidades;

namespace ModuloAPI.Interfaces
{
    public interface IVeiculoRepository
    {
        public Veiculo CadastrarVeiculo(VeiculoDTO veiculo);

        public void DeletarVeiculo(string Nome_Veiculo);
        

    }
}
