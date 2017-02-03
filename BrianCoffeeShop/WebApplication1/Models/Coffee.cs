using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Coffee
    {
        //CoffeeID. This is the primary key
        public int CoffeeID { get; set; }

        //BrandID. The Brand of the coffee
        [Required]
        public int BrandID { get; set; }

        //Name. The name of the coffee
        [Required]
        public string Name { get; set; }

        //PhotoFile. This is a picture file
        [DisplayName("Picture")]
        [MaxLength]
        public byte[] PhotoFile { get; set; }

        //ImageMimeType, stores the MIME type for the PhotoFile
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        //Description.
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //UserName. This is the name of the user who created the photo
        public string UserName { get; set; }

        //All the comments on this photo, as a navigation property
        public virtual ICollection<Comment> Comments { get; set; }

    }
}