using prueba_tecnica_softkaU.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Models
{
    public class Round : EntityBase
    {
        public Round()
        {
            Status = Status.Create;
        }
        public int CurrentRound { get; set; }

        public double Points { get; set; }

        [ForeignKey("OptionId")]
        public int? OptionId { get; set; }
        public virtual Option Option { get; set; }


        [ForeignKey("MatchId")]
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }

        public Status Status { get; set; }
    }
}
