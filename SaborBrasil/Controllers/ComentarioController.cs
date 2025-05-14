using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using SaborBrasil.Data;
using SaborBrasil.Models;

[ApiController]
[Route("api/[controller]")]
public class ComentariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ComentariosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/comentarios?postId=1
    [HttpGet]
    public async Task<IActionResult> GetComentarios([FromQuery] int postId)
    {
        var comentarios = await _context.Comentarios
            .Where(c => c.Post_Id == postId)
            .OrderByDescending(c => c.Created_At).Join(_context.Usuarios,
              c => c.Id_Usuario,
              u => u.IdUsuario,
              (c, u) => new {
                  c.IdComentario,
                  c.Descricao,
                  c.Id_Usuario,
                  c.Data,
                  c.Post_Id,
                  c.Created_At,
                  NomeUsuario = u.Nome // <-- Nome do usuário
              })
            .ToListAsync();

        return Ok(comentarios);
    }

    // POST: api/comentarios
    [HttpPost]
    public async Task<IActionResult> PostComentario([FromBody] Comentario comentario)
    {
        if (comentario == null || string.IsNullOrWhiteSpace(comentario.Descricao))
            return BadRequest(new { message = "Comentário inválido." });

        
        

        _context.Comentarios.Add(comentario);
        await _context.SaveChangesAsync();

        return Ok(comentario);
    }
}