using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Models
{
    public class Question : EntityBase
    {

        public string Description { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public List<Option> Options { get; set; }
    }
}
