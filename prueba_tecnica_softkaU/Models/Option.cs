using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Models
{
    public class Option : EntityBase
    {

        public string Description { get; set; }

        public bool Correct { get; set; }


        [ForeignKey("QuestionId")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public List<Round> Rounds { get; set; }
    }
}
