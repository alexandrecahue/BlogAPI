using System;
namespace BlogAPI.src.entities;
public class User
{
    public int Id { get; set; }  

    public string? NomeUsuario { get; set; }  
    public string? EmailDoUsuario { get; set; }     
    public string? Password { get; set; }  

    public string? Role { get; set; }  

    public ICollection<Post>? Posts { get; set; }  
}
