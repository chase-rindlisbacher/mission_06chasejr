using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Movie_mission6.Models
{
    /*Store values from the form to variables and make getters and setters for each*/
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int? Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string Lent_to { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
        [Required]
        // Build Foreign Key Migrations
        public int CategoryID { get; set; }
        public MovieCategory Category { get; set; }
    }
}
