using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library.Models
{

   public enum CopyStates { available, stoled, burned, readjustinplace };
    public class PublicationCopy
    {
        [Key]
        [Required(ErrorMessage = "PublicationCopyId is required")]
        public int PublicationCopyId
        {
            get;
            set;
        }

        public Publication Publicationp
        {
            get;
            set;
        }

        public int RackNumber
        {
            get;
            set;
        }

        public int RowNumber
        {
            get; set;
        }

        public CopyStates CopyState
        {
            get; set;
        }


        public bool Loaned
        {
            get;
        }

        public Member Borrower
        {
            get;
            set;
        }

        public int ExpirationDate
        {
            get;
            set;
        }

    }
}