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
        public string user { get; set; }
        public IEnumerable<Joker.Models.ApplicationUser> Following { get; set; }
        public IEnumerable<Joker.Models.ApplicationUser> Followers { get; set; }
    }
}