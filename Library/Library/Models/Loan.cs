using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Library.Models
{
    public class Loan
    {
        [Required()]
        public Member Memberp { get; set; }

        [Required()]
        public Publication Publicationp { get; set; }

        [Required()]
        public DateTime Date { get; set; }

    }
}