using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaborBrasil.Models
{
    public class Comentario
{
    [Key]
    [Column("idcomentario")]
    public int IdComentario { get; set; }
    
    [Column("descricao")]
    public string? Descricao { get; set; }
    [Column("id_usuario")]
    public int? Id_Usuario { get; set; }
    [Column("data")]
    public DateTime? Data { get; set; }
    [Column("id_post")]
    public int? Post_Id { get; set; }
    [Column("id_comentario_pai")]
    public DateTime Created_At { get; set; } = DateTime.Now;
}
}
