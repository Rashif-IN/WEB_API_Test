using System;
using System.Collections.Generic;

namespace WEBAPI_Test.Model
{
    public class Author
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string email { get; set; }
        public string profile { get; set; }
    }
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public List <string> tags { get; set; }
        public string create_time { get; set; }
        public string update_time { get; set; }
        public int author_id { get; set; }
    }
    public class Comment
    {
        public int id { get; set; }
        public string content { get; set; }
        public string create_time { get; set; }
        public int author_id { get; set; }
        public string email { get; set; }
        public string url { get; set; }
        public int post_id { get; set; }
    }
}
