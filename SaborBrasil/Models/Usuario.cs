using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaborBrasil.Models
{
    [Table("Usuario")] // Mapeia explicitamente para a tabela "Usuario"
    public class Usuario
    {
        [Key]
        [Column("idusuario")] // Mapeia para a coluna "idusuario"
        public int IdUsuario { get; set; }

        [Column("nome")] // Mapeia para a coluna "nome"
        public string? Nome { get; set; }

        [Required]
        [Column("CPF")] // Mapeia para a coluna "CPF"
        public string CPF { get; set; }

        [Required]
        [Column("senha")] // Mapeia para a coluna "senha"
        public string Senha { get; set; }

        [Required]
        [Column("telefone")] // Mapeia para a coluna "telefone"
        public string Telefone { get; set; }

        [Column("email")] // Mapeia para a coluna "email"
        public string? Email { get; set; }

        [Column("created_at")] // Mapeia para a coluna "created_at"
        public DateTime CreatedAt { get; set; }
    }
}
