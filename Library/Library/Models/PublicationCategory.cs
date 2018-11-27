using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library.Models
{
    [Table("PublicationCategory")]
    public class PublicationCategory
    {
        
        [Key]
        [StringLength(20, ErrorMessage = "Must be under 10 characters")]
        [Required(ErrorMessage = "Release date is required")]
        public string CategoryID
        {
            get; set;
        }

        [StringLength(100, ErrorMessage = "Must be under 10 characters")]
        [Required(ErrorMessage = "Release date is required")]
        public string Name
        {
            get; set;
        }
    }

    public class PublicationCategoryViewModel
    {
        public List<PublicationCategory> PublicationCategories { get; set; }
        public PublicationCategory SelectedPublicationCategory { get; set; }
        public string DisplayMode { get; set; }
    }

}