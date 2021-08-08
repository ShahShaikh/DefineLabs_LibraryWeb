using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DefineLabs_Library.Models
{
    public class Author
    {
        
        public int authorId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]

        [Display(Name = "Date Of Birth")]
        public DateTime dateOfBirth { get; set; }
        public List<Book> books { get; set; }

        public string AuthorIDs { get; set; }

    }
}