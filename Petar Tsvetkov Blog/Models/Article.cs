using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Petar_Tsvetkov_Blog.Models
{
    public class Article
    {
        [Key]
        public  int Id { get; set; }

        [Required] 
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        public string Content { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual AplicationUser Author { get; set; }

        public bool IsAuthor(string name)
        {
            return this.Author.UserName.Equals(name);
        }
    }
}