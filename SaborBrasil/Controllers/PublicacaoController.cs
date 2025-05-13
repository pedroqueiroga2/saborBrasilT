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

                var filePath = Path.Combine(uploads, imagem.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imagem.CopyTo(stream);
                }
                publicacao.Imagem = "/uploads/" + imagem.FileName;
            }

            // Para teste, defina um usuário existente no banco
            publicacao.UsuarioId = 1;

            Console.WriteLine($"Nome: {publicacao.Nome}, Descricao: {publicacao.Descricao}, Imagem: {publicacao.Imagem}");

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
}