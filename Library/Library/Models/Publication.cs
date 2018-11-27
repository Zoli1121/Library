using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Publication
    {
        [Key]
        [StringLength(13, MinimumLength = 13)]
        [Required(ErrorMessage = "ISBN required")]
        public string ISBN
        {
            get; set;
        }

        [StringLength(100, ErrorMessage = "Must be under 100 characters")]
        [Required(ErrorMessage = "Title required")]
        public string Title
        {
            get; set;
        }


        public List<Author> Authors
        {
            get; set;
        }

        public int PublicationDate
        {
            get; set;
        }

        [Required(ErrorMessage = "Categories required")]
        public List<PublicationCategory> Categories
        {
            get; set;
        }

        [Required(ErrorMessage = "PageNumber required")]
        public int PageNumber
        {
            get; set;
        }

        [StringLength(100, ErrorMessage = "Must be under 200 characters")]
        public string Remark
        {
            get; set;
        }






    }
}