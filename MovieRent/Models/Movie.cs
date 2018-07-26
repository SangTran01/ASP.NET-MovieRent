using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRent.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required, Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required, Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        [Required, Display(Name = "Number In Stock")]
        [Range(1,10000, ErrorMessage = "Must have at least 1 in-stock.")]
        public int NumberInStock { get; set; }
    }
}