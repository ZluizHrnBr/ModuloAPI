using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModuloAPI.Entidades
{
    [Table("tb_usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id_Usuario { get; set; }

        [Required]
        public string NomeUsuario { get; set; }

        [Required]
        
        public string Senha { get; set; }
  
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }    
    }
}
