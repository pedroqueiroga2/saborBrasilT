using Microsoft.AspNetCore.Mvc;
using SaborBrasil.Data;
using SaborBrasil.Models; // Certifique-se de importar o namespace correto

public class UsuarioController : Controller
{
    private readonly AppDbContext _context;

    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Cadastrar(Usuario usuario)
    {
        if (ModelState.IsValid)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Redirect("/index.html"); // Redireciona para o index.html após o cadastro
        }

        return View("Erro"); // Exibe uma página de erro se algo der errado
    }
    [HttpPost("Login")]
    public IActionResult Login([FromBody] Usuario usuario)
    {
        // Busca o usuário no banco de dados pelo e-mail
        var usuarioExistente = _context.Usuarios
            .FirstOrDefault(u => u.Email.ToLower() == usuario.Email.ToLower());

        if (usuarioExistente == null)
        {
            return BadRequest(new { message = "Usuário não encontrado." });
        }

        // Verifica se a senha está correta
        if (usuarioExistente.Senha != usuario.Senha)
        {
            return BadRequest(new { message = "Senha incorreta." });
        }

        // Retorna sucesso (você pode adicionar um token JWT aqui, se necessário)
        return Redirect("/index.html");
    }
}
