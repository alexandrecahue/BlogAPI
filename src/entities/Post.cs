public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; } // Chave estrangeira
    public User User { get; set; } // Relação com a entidade User
}
