using ModuloAPI.Context;
using ModuloAPI.DTO;
using ModuloAPI.Entidades;
using ModuloAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModuloAPI.Services
{
    public class VeiculoServices : IVeiculoRepository
    {

        public readonly DataBaseContext _context;
        public VeiculoServices(DataBaseContext context) 
        {
            _context = context;
        }

        
        public Veiculo CadastrarVeiculo(VeiculoDTO veiculo)
        {
            var Veiculo = new Veiculo()
            {
                Nome_Veiculo = veiculo.Nome_Veiculo,
                Marca_Veiculo = veiculo.Marca_veiculo,
                Ano_Veiculo = veiculo.Ano_Veiculo
            };

            _context.Veiculos.Add(Veiculo);
            var salvar = _context.SaveChanges();
            return Veiculo;
        }

        public int DeletarVeiculo(string Nome_Veiculo)
        {
            try
            {
                var Veiculo = _context.Veiculos
                .FirstOrDefault(x => x.Nome_Veiculo == Nome_Veiculo);

                _context.Remove(Veiculo);
                var salvar = _context.SaveChanges();

                return salvar;
            }
            catch(Exception e)
            {
                throw new Exception($"Erro ao deletar dado no banco de dados, possivelmente o nome {Nome_Veiculo} não existe no banco.");

            }
        }

        public List<VeiculoDTO> ListarVeiculos()
        {
            var Veiculos = _context.Veiculos
                .Select(a => new VeiculoDTO(a.Id_Veiculo, a.Nome_Veiculo, a.Marca_Veiculo, a.Ano_Veiculo ))
                .ToList();

            return Veiculos;
        }


        public Veiculo AtualizarVeiculo(VeiculoDTO veiculo)
        {
            var Veiculo = _context.Veiculos.FirstOrDefault(v => v.Nome_Veiculo == veiculo.Nome_Veiculo);

            if (Veiculo != null)
            {
                Veiculo.Marca_Veiculo = veiculo.Marca_veiculo;
                Veiculo.Ano_Veiculo = veiculo.Ano_Veiculo;

                var salvar = _context.SaveChanges();
            }

            return Veiculo; 
        }
    }
}
