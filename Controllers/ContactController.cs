using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEBAPI_Test.Model;

namespace WEBAPI_Test.Controllers
{
    [ApiController]
    [Route("userss")]
    public class ContactController : ControllerBase
    {
        private static List<User> Users = new List<User>()
        {
            new User(){Id=1, Name="X", Username="Xzy"},
            new User(){Id=2, Name="A", Username="Abc"},
            new User(){Id=3, Name="Q", Username="Qrp"},
            new User(){Id=4, Name="R", Username="Rsu"},
            new User(){Id=5, Name="U", Username="Uganda"}
        };

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok(Users);
            return Ok(new { status = "success", message = "success get data", data = Users });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(Users.Find(e => e.Id == id));
        }

        [HttpPost]
        public IActionResult ContactAdd(UserRequest user)
        {
            var userAdd = new User() { Id = 6, Username = user.Username, Name = user.Name };
            Users.Add(userAdd);
            return Ok(Users);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(Users.RemoveAll(e => e.Id == id));
        }

        [HttpPatch("{id}")]
        public IActionResult PatchUser(int id)
        {
            return Ok(Users.Find(e => e.Id == id));

        }
    

    }
}