using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library.Models
{
    [Table("TestTable")]
    public class Author
    {
        [Key]
        [StringLength(20, ErrorMessage = "Must be under 20 characters")]
        [Required()]
        public string AuthorID
        {
            get; set;
        }
       
        [StringLength(100, ErrorMessage = "Must be under 100 characters")]
        [Required()]
        public string Name
        {
            get; set;
        }
       
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string Nationality
        {
            get; set;
        }

        public int BirthDate
        {
            get; set;
        }
       
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string Birthplace
        {
            get; set;
        }
       
        public int DeathDate
        {
            get; set;
        }

        [StringLength(50, ErrorMessage = "Must be under 200 characters")]
        public string Remark
        {
            get; set;
        }

    }
}