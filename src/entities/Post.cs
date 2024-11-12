using System;
namespace BlogAPI.src.entities;
public class Post
{
    public int Id { get; set; }
    public string? TituloDoPost { get; set; }
    public string? ConteudoDoPost { get; set; }
    public DateTime CriadoEm { get; set; }
    public int IdDoUsuario { get; set; }
    public User? Usuario { get; set; }
}
