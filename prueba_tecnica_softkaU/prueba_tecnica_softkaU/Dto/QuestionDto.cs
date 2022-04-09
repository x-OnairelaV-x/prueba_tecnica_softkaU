using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Dto
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName{ get; set; }

        public List<OptionsDto> Options { get; set; }
    }

    public class OptionsDto
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}

