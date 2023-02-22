using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_mission6.Models
{
    /*New Category table made*/
    public class MovieCategory
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }
        public string Category { get; set; }
    }
}
