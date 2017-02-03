using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Comment
    {
        //CommentID. This is the Primary Key
        public int CommentID { get; set; }

        //CoffeeID. This is the ID of the coffee that this comment relates to
        public int CoffeeID { get; set; }

        //UserName. This is the name of the user who made this comment
        public string UserName { get; set; }

        //Subject.  
        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        //Body
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        //Coffee. This is the coffee that this comment relates to as a navigation property
        public virtual Coffee coffee { get; set; }
    }
}