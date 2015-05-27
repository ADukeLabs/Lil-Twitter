using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joker.Models
{
    public class Joke
    {
        public int Id { get; set; }
        public string JokeTitle { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}