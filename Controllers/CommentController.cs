using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI_Test.Model;

namespace WEBAPI_Test.Controllers
{
    [ApiController]
    [Route("comment")]
    public class CommentController : ControllerBase
    {
        private static List<Comment> Comments = new List<Comment>()
        {
            new Comment(){id=1, content="it's great!", create_time= "2019", author_id=3, email="nsrh@hrd.com", url="www.github.com", post_id = 1},
            new Comment(){id=2, content="it's bizare!", create_time= "2019", author_id=2, email="nsrh@hrd.com", url="www.github.com", post_id = 2},
            new Comment(){id=3, content="it's weird!", create_time= "2019", author_id=4, email="nsrh@hrd.com", url="www.github.com", post_id = 3},
            new Comment(){id=4, content="it's great!", create_time= "2019", author_id=2, email="nsrh@hrd.com", url="www.github.com", post_id = 4}
            
        };

        private readonly ILogger<PostController> _logger;

        public CommentController(ILogger<PostController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(Users); 
            return Ok(new { status = "success", message = "success get data", data = Comments });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(Comments.Find(e => e.id == Id));
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            var commentAdd = new Comment() { id = comment.id, content = comment.content, create_time = comment.create_time, author_id = comment.author_id, email = comment.email, url = comment.url, post_id = comment.post_id };
            Comments.Add(commentAdd);
            return Ok(Comments);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int Id)
        {
            return Ok(Comments.RemoveAll(e => e.id == Id));
        }

        //[HttpPatch("{id}")]
        //public IActionResult CommentPatch(int Id, Comment comment)
        //{
        //    Comment A = Comments.Where(e => e.id == Id).First();
        //    int index = Comments.IndexOf(A);
        //    if (comment.id == 0)
        //    {
        //        comment.id = A.id;
        //    }
        //    if (comment.content == null)
        //    {
        //        comment.content = A.content;
        //    }
        //    if (comment.create_time == null)
        //    {
        //        comment.create_time = A.create_time;
        //    }
        //    if (comment.author_id == 0)
        //    {
        //        comment.author_id = A.author_id;
        //    }
        //    if (comment.email == null)
        //    {
        //        comment.email = A.email;
        //    }
        //    if (comment.url == null)
        //    {
        //        comment.url = A.url;
        //    }
        //    if (comment.post_id == 0)
        //    {
        //        comment.post_id = A.post_id;
        //    }
        //    Comments[index] = new Comment() { id = comment.id, content = comment.content, create_time = comment.create_time, author_id = comment.author_id, email = comment.email, url = comment.url, post_id = comment.post_id };

        //    return Ok(Comments);
        //}

        [HttpPatch("{id}")]
        public IActionResult PatchAuthor([FromBody]JsonPatchDocument<Comment> patch, int Id)
        {
            patch.ApplyTo(Comments.Find(e => e.id == Id));

            return Ok(Comments.Find(e => e.id == Id));
        }
    }
}
