using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Models.Models
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        [ForeignKey("LevelId")]
        public int LevelId { get; set; }
        public virtual Level Level { get; set; }

        public List<Question> Questions { get; set; }
    }
}
