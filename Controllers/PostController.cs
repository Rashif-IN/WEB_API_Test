using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI_Test.Model;

namespace WEBAPI_Test.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostController : ControllerBase
    {
        private static List<Post> Posts = new List<Post>()
        {
            new Post(){id=1, title="One Piece", content="adventure about the straw hat pirates", tags= new List<string>{"pirate","adventure","treasure","fighting" }, create_time="1995", update_time="2020", author_id=3},
            new Post(){id=2, title="Jojo's Bizare Adventure", content="it is an adventure of a guy named jojo", tags=new List<string>{"british","adventure","bizare","fighting" }, create_time="1970", update_time="2019", author_id=2},
            new Post(){id=3, title="Scobydoo", content="a mystery solving team consist of a few people and a dog", tags=new List<string>{"mystery","adventure","crime","chasing" }, create_time="1990", update_time="2012", author_id=4},
            new Post(){id=4, title="Jojo's Bizare Adventure : Golden Wing", content="it is an adventure of a guy named girno givana", tags=new List<string>{"italy","adventure","bizare","fighting" }, create_time="1989", update_time="2019", author_id=2}
        };

        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(Users); 
            return Ok(new { status = "success", message = "success get data", data = Posts });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(Posts.Find(e => e.id == Id));
        }

        [HttpPost]
        public IActionResult PostAdd(Post post)
        {
            var postAdd = new Post() { id = post.id, title = post.title, content = post.content, tags = post.tags, create_time = post.create_time, update_time = post.update_time, author_id = post.author_id };
            Posts.Add(postAdd);
            return Ok(Posts);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int Id)
        {
            return Ok(Posts.RemoveAll(e => e.id == Id));
        }

    }
}
