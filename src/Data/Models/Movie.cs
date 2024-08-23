using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActorId { get; set; }
        public int DirectorId { get; set; }
    }
}
