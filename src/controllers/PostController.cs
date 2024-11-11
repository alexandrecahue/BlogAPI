using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Migrations; 
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly BlogContext _context;

        public PostController(BlogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await _context.Posts
                                       .OrderByDescending(p => p.CreatedAt)
                                       .ToListAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            var userId = User.FindFirst("sub")?.Value;  

            if (userId == null)
            {
                return Unauthorized();
            }

            post.UserId = int.Parse(userId); 
            post.CreatedAt = DateTime.UtcNow;

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            var existingPost = await _context.Posts.FindAsync(id);

            if (existingPost == null)
            {
                return NotFound();
            }

            var userId = User.FindFirst("sub")?.Value; 
            if (existingPost.UserId.ToString() != userId)
            {
                return Unauthorized();
            }

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.CreatedAt = DateTime.UtcNow;

            _context.Entry(existingPost).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

          
            var userId = User.FindFirst("sub")?.Value; 
            if (post.UserId.ToString() != userId)
            {
                return Unauthorized();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
