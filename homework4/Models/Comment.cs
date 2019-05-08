using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace homework4.Models
{
    public class Comment
    {
        public Comment() { }

        public Comment(string text, string author)
        {
            Text = text;
            Author = author;
        }

        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Author is too long! This was validated on the server.")]
        public string Author { get; set; }

    }

}