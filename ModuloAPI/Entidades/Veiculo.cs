using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloAPI.Entidades
{
    [Table("tb_veiculo")]
    public class Veiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id_Veiculo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome_Veiculo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Marca_Veiculo { get; set; }

        [Required]
        public int Ano_Veiculo { get; set; }
     }
}
