using CoreAdmin_BlogSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAdmin_BlogSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly TestDbContext _context;
        private readonly ILogger<BlogController> _logger;

        public BlogController(TestDbContext context, ILogger<BlogController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet(Name = "GetBlogPosts")]
        public IEnumerable<BlogPost> Get()
        {
            return _context.BlogPosts
                .Where(m => m.Public == true)
                .OrderBy(m => m.Created)
                .ToList();
        }

        [HttpGet("{id:Guid}", Name = "GetBlogPostDetails")]
        public BlogPost? Details(Guid? id)
        {
            if (id == null)
                return null;

            var product = _context.BlogPosts
                .Where(m => m.Public == true)
                .FirstOrDefault(m => m.Id == id);

            return product;
        }

        [HttpGet("{slug}", Name = "GetBlogPostDetailsBySlug")]
        public BlogPost? DetailsBySlug(string? slug)
        {
            if (slug == null)
                return null;

            var product = _context.BlogPosts
                .Where(m => m.Public == true)
                .FirstOrDefault(m => m.Slug == slug);

            return product;
        }
    }
}
