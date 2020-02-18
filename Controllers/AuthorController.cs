using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI_Test.Model;


namespace WEBAPI_Test.Controllers
{
    [ApiController]
    [Route("author")]
    public class AuthorController : ControllerBase
    {
        private static List<Author> Authors = new List<Author>()
        {
            new Author(){id=1, username="gudangGRM", password="gudanggaram", salt="gudang garam", email="gundang@gmail.com", profile="gudang garam adalah produsen garam terkenal"},
            new Author(){id=2, username="ArakiH", password="goldexperience", salt="garam meja", email="araki_jojo@gmail.com", profile="hirohiko araki adalah penulis manga jojo bizare adventure"},
            new Author(){id=3, username="E.Oda", password="gear6incoming", salt="garam beryodium", email="Oda.OP@gmail.com", profile="Eichiro Oda adalah penulis manga One Piece"},
            new Author(){id=4, username="W-Shake", password="bigspear", salt="garam jadul", email="shakespear@gmail.com", profile="wiliam shakespear adalah penulis puisi terkenal yang mendunia"}
        };

        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILogger<AuthorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(Users);
            return Ok(new { status = "success", message = "success get data", data = Authors });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(Authors.Find(e => e.id == Id));
        }

        [HttpPost]
        public IActionResult AuthorAdd(Author author)
        {
            //var userAdd = new Author() { id = author.id, username = author.username, password = author.password, salt = author.salt , email = author.email, profile = author.profile };
            //Authors.Add(userAdd);
            //return Ok(Authors);
            return Ok(Authors.Append(author));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int Id)
        {
            return Ok(Authors.RemoveAll(e => e.id == Id));
        }

        [HttpPatch("{id}")]
        public IActionResult AuthorPatch(int Id, Author author)
        {
            Author A  = Authors.Where(e => e.id == Id).First();
            int index = Authors.IndexOf(A);
            if(author.id==0)
            {
                author.id = A.id;
            }
            if (author.username == null)
            {
                author.username = A.username;
            }
            if (author.password == null)
            {
                author.password = A.password;
            }
            if (author.salt == null)
            {
                author.salt = A.salt;
            }
            if (author.email == null)
            {
                author.email = A.email;
            }
            if (author.profile == null)
            {
                author.profile = A.profile;
            }
            Authors[index] = new Author() { id = author.id, username = author.username, password = author.password, salt = author.salt, email = author.email, profile = author.profile };
            
            return Ok(Authors);
        }

        //[HttpPatch("{id}")]
        //public IActionResult AuthorPatch([FromBody] JsonPatchDocument<Author> author, Author authoradd, int Id)
        //{
        //    var AuP = Authors.Find(e => e.id == Id);
        //    if (author != null)
        //    {
        //        var userAdd = AuthorAdd(authoradd);

        //        author.ApplyTo(userAdd, ModelState);

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        return new ObjectResult(userAdd);
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        //[HttpPatch("{id}")]
        //public IActionResult PatchAuthor([FromBody]JsonPatchDocument<Author> patch, Author authoradd, int Id)
        //{
        //    var userAdd = AuthorAdd(authoradd);
        //    //var userAdd = new Author() { id = X.id, username = X.username, password = X.password, salt = X.salt, email = X.email, profile = X.profile };
        //    patch.ApplyTo(Authors);



        //    return Ok(userAdd);
        //}

    }
}
