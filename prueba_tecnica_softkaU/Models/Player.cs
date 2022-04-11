using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Models
{
    public class Player : EntityBase
    {
        public string Name { get; set; }
        public List<Match> Matches { get; set; }
    }
}
