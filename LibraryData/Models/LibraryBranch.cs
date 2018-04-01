using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class LibraryBranch
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [StringLength(30,ErrorMessage ="Limit branch name to 30 chars.")]
        public string Name { get; set; }


        
        [Required]
        public string address { get; set; }


        [Required]
        public string Telephone { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }


        public virtual IEnumerable<Patron> Patrons { get; set; }
        public virtual IEnumerable<LibraryAsset> LibraryAssets { get; set; }

        public virtual string ImageUrl { get; set; }





    }
}
