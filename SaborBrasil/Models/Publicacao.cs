using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaborBrasil.Models
{
    [Table("Publicacao")]
    public class Publicacao
    {
        [Key]
        [Column("idpost")]
        public int IdPost { get; set; }

        [Required]
        [MaxLength(45)]
        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Column("Imagem")]
        public string? Imagem { get; set; }

        [Column("UsuarioId")]
        public int? UsuarioId { get; set; }

        [Column("dataPublicao")]
        public DateTime DataPublicao { get; set; } = DateTime.Now;
    }
}