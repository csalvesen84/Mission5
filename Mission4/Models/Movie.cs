using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mission4.Models {
    public class Movie {
        [Key]
        [Required]
        public int MovieId { get; set; }
        //Build a foreign key relationship
        [Required]
        public int? CategoryID { get; set; }
        public Category Category { get; set; }


        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1888, Double.PositiveInfinity)]
        public short Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
