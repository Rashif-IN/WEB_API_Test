using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI_Test.Middleware;
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
            
            return Ok(Authors.Append(author));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int Id)
        {
            
            return Ok(Authors.RemoveAll(e => e.id == Id));
        }

        

        [HttpPatch("{id}")]
        public IActionResult PatchAuthor([FromBody]JsonPatchDocument<Author> patch, int Id)
        {
            
            patch.ApplyTo(Authors.Find(e => e.id == Id));
            
            return Ok(Authors.Find(e => e.id == Id));
        }

    }
}

//[
//	{
//		"do" : "replace",
//		"path" : "username",
//		"value" : "hftdhrdhbxdehrx"
		
//	},
//	{
//		"do" : "replace", 
//		"path" : "salt",
//		"value" : "xf57uxd 6s4e6"
		
//	}
//]
//IP nya ip request