using System;
using System.ComponentModel.DataAnnotations;

namespace OverripeBananas.Models
{
    public class Show
    {
        public int ID { get; set; }

        [Display(Name = "Show")]
        [StringLength(75, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        public string Genre { get; set; }

        public string Rating { get; set; }
    }
}
