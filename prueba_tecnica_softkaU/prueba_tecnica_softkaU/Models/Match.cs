using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Models
{
    public class Match : EntityBase
    {
        public Match()
        {
            TotalPoints = 0;
        }

        public Double TotalPoints { get; set; }

        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public List<Round> Rounds { get; set; }
        public bool CompleteGame { get; set; }
    }
}
