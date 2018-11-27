using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public enum EventTypes { Loan, Back};
    public class Logbook
    {
        [Key]
        [Required()]
        public int LogBookId { get; set; }

        [Required()]
        public int EventDate { get; set; }

        [Required()]
        public Member Memberp { get; set; }

        [Required()]
        public PublicationCopy Publicationcopy { get; set; }



        [Required()]
        public EventTypes EventType { get; set; }


    }
}