using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joker.Models
{
    public class JokeViewModel
    {
        public IEnumerable<Joker.Models.Joke> JokeList { get; set; }
        public Joke joke { get; set; }
    }
}