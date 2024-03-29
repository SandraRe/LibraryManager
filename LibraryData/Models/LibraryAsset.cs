﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public abstract class LibraryAsset
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int NumberOfCopies { get; set; }

        [Required]
        public virtual LibraryBranch Location { get; set; }

    }
}
