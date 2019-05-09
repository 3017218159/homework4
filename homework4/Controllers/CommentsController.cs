using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using homework4.Models;

namespace homework4.Controllers
{
    public class CommentsController : ApiController
    {
        private static List<Comment> comments = new List<Comment>()
        {
            new Comment{ID=1, Author="User1", Text="Hello1"},
            new Comment{ID=2, Author="User2", Text="Hello2"},
            new Comment{ID=3, Author="User3", Text="Hello3"}
        };

        private static List<int> ids = new List<int>
        {
            1,2,3
        };

        public IEnumerable<Comment> Get()
        {
            return comments;
        }

        public Comment Get(int id)
        {
            var comment = comments.FirstOrDefault((p) => p.ID == id);
            if (comment == null)
            {
                return new Comment { ID = 0, Author = "Null", Text = "False ID" };
            }
            else
            {
                int index = ids.IndexOf(id);
                return comments[index];
            }
        }

        // POST api/values
        public string Post([FromBody]Comment comment)
        {
            if (!ids.Contains(comment.ID))
            {
                comments.Add(new Comment { ID = comment.ID, Author = comment.Author, Text = comment.Text });
                ids.Add(comment.ID);
                return "Created";
            }
            else
            {
                return "ID is Exist";
            }
        }

        // PUT api/values/5
        public string Put(int id, [FromBody]Comment comment)
        {
            if (ids.Contains(id))
            {
                int index = ids.IndexOf(id);
                comments[index].Author = comment.Author;
                comments[index].Text = comment.Text;
                return "Updated";
            }
            else
            {
                return "ID is not exist";
            }
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            if (ids.Contains(id))
            {
                int index = ids.IndexOf(id);
                ids.Remove(id);
                comments.RemoveAt(index);
                return "Deleted";
            }
            else
            {
                return "ID is not exist";
            }
        }
    }
}
