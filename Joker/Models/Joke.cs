using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Joker.Models
{
    public class Joke
    {
        public int Id { get; set; }
        [MaxLength(140)]
        [Required]
        [Display(Name = "Latest...")]
        public string JokeTitle { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}