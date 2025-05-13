using Microsoft.AspNetCore.Mvc;
using SaborBrasil.Data;
using SaborBrasil.Models; // Certifique-se de importar o namespace correto

[Route("Usuario")] // Define a rota base para o controlador
public class UsuarioController : Controller
{
    private readonly AppDbContext _context;

    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("Cadastrar")]
    public IActionResult Cadastrar(Usuario usuario)
    {
        if (!ModelState.IsValid)
        {
            // Loga todos os erros de validação
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View("Erro");
        }

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return Redirect("/index.html"); // Redireciona para o index.html após o cadastro
    }
    [HttpPost("Login")] // Define que este método será acessado via POST em /Usuario/Login
    public IActionResult Login([FromBody] Usuario usuario)
    {
        if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
            return BadRequest(new { message = "E-mail e senha são obrigatórios." });

        var usuarioExistente = _context.Usuarios
            .FirstOrDefault(u => u.Email.ToLower() == usuario.Email.ToLower());

        if (usuarioExistente == null)
            return BadRequest(new { message = "Usuário não encontrado." });

        if (usuarioExistente.Senha != usuario.Senha)
            return BadRequest(new { message = "Senha incorreta." });

        // Retorne o idusuario!
        return Ok(new { 
            message = "Login realizado com sucesso!",
            idusuario = usuarioExistente.IdUsuario // <-- ESSA LINHA É FUNDAMENTAL
        });
    }
}
