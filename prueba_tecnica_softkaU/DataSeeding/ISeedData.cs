using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.DataSeeding
{
    public interface ISeedData
    {
        public void AddLevelData(ModelBuilder modelBuilder);
        public void AddCategoryData(ModelBuilder modelBuilder);
        public void AddQuestionsData(ModelBuilder modelBuilder);
        public void AddOptionsData(ModelBuilder modelBuilder);
    }
}
