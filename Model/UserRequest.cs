using System;
namespace WEBAPI_Test.Model
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Name { get; set; }
    }

    public class User : UserRequest
    {
        public int Id { get; set; }
    }
}
