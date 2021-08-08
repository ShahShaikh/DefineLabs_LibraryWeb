using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DefineLabs_Library.Models
{
    public class Book
    {

        [Display(Name = "Book ID")]
        public int bookID { get; set; }

        [Required]
        [Display(Name ="Book Title")]
        public string bookTitle { get; set; }

        public int authorID { get; set; }

    }
}