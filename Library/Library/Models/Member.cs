using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public enum States { Active, Passiv };
    public class Member
    {
        [Key]
        [Required()]
        public int MemberId
        {
            get;
            set;
        }

        [StringLength(100, ErrorMessage = "Must be under 100 characters")]
        [Required()]
        public string Name
        {
            get;
            set;
        }

        [StringLength(100, ErrorMessage = "Must be under 100 characters")]
        [Required()]
        public string MotherName
        {
            get;
            set;
        }

        [StringLength(100, ErrorMessage = "Must be under 100 characters")]
        [Required()]
        public string Address
        {
            get;
            set;
        }

       
        [Required()]
        public States State
        {
            get; set;
        }

  
        public List<PublicationCopy> LentPublicationCopies
        {
            get;
            set;
        }

    }

}