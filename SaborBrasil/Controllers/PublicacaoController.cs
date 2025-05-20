using Microsoft.AspNetCore.Mvc;
using SaborBrasil.Data;
using SaborBrasil.Models;

[Route("api/publicacoes")]
[ApiController]
public class PublicacaoController : ControllerBase
{
    private readonly AppDbContext _context;

    public PublicacaoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("Criarpublicacao")]
    public IActionResult CriarPublicacao([FromForm] Publicacao publicacao, [FromForm] IFormFile? imagem)
    {
        Console.WriteLine("Método CriarPublicacao chamado!");
        try
        {
            if (imagem != null)
            {
                var uploads = Path.Combine("wwwroot/uploads");
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                // Gera um nome único para a imagem
                var ext = Path.GetExtension(imagem.FileName);
                var uniqueName = $"{Guid.NewGuid()}{ext}";
                var filePath = Path.Combine(uploads, uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imagem.CopyTo(stream);
                }
                publicacao.Imagem = "/uploads/" + uniqueName;
            }

            _context.Publicacoes.Add(publicacao);
            _context.SaveChanges();

            return Ok(new { message = "Publicação criada com sucesso!" });
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERRO AO CADASTRAR PUBLICAÇÃO: " + ex.Message);
            return BadRequest(new { message = "Erro ao criar publicação: " + ex.Message });
        }
        
    }

    [HttpGet("Listar")]
    public IActionResult Listar()
    {
        var publicacoes = _context.Publicacoes.Join(_context.Usuarios,
              pub => pub.UsuarioId,
              user => user.IdUsuario,
              (pub, user) => new {
                  pub.IdPost,
                  pub.Nome,
                  pub.Descricao,
                  pub.Imagem,
                  pub.UsuarioId,
                  pub.DataPublicao,
                  Autor = user.Nome // <-- Aqui pega o nome do usuário
              })
            .OrderByDescending(p => p.DataPublicao)
            .ToList();
        return Ok(publicacoes);
    }

    public class LikeRequest
    {
        public int idPost { get; set; }
        public int idUsuario { get; set; }
    }

    [HttpPost("Like")]
    public IActionResult Like([FromBody] LikeRequest req)
    {
        var jaCurtiu = _context.Likes.Any(l => l.IdUsuario == req.idUsuario && l.IdPost == req.idPost);
        if (jaCurtiu)
            return BadRequest(new { message = "Você já curtiu esta publicação." });

        var like = new Like { IdUsuario = req.idUsuario, IdPost = req.idPost };
        _context.Likes.Add(like);
        _context.SaveChanges();
        return Ok(new { message = "Like registrado!" });
    }
    

    [HttpDelete("Like")]
    public IActionResult RemoverLike([FromBody] LikeRequest req)
    {
        var like = _context.Likes.FirstOrDefault(l => l.IdUsuario == req.idUsuario && l.IdPost == req.idPost);
        if (like == null)
            return NotFound(new { message = "Like não encontrado." });

        _context.Likes.Remove(like);
        _context.SaveChanges();
        return Ok(new { message = "Like removido com sucesso." });
    }

    [HttpGet("LikesCount/{idPost}")]
    public IActionResult LikesCount(int idPost)
    {
        var count = _context.Likes.Count(l => l.IdPost == idPost);
        return Ok(new { likes = count });
    }

    [HttpGet("UserLiked")]
    public IActionResult UserLiked([FromQuery] int postId, [FromQuery] int userId)
    {
        var liked = _context.Likes.Any(l => l.IdPost == postId && l.IdUsuario == userId);
        return Ok(new { liked });
    }
}