using Microsoft.EntityFrameworkCore;
using prueba_tecnica_softkaU.Models;
using prueba_tecnica_softkaU.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.DataSeeding
{
    public class SeedData : ISeedData
    {
        public void AddCategoryData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                       new Category { Id = 1, Name = "Deportes", LevelId = 1 },
                       new Category { Id = 2, Name = "Matematicas", LevelId = 2 },
                       new Category { Id = 3, Name = "Cultura", LevelId = 3 },
                       new Category { Id = 4, Name = "Musica", LevelId = 4 },
                       new Category { Id = 5, Name = "Ciencia", LevelId = 5 }
                        );
        }

        public void AddLevelData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Level>().HasData(
                new Level { Id = 1, Difficulty = 1, Points = 100 },
                new Level { Id = 2, Difficulty = 2, Points = 200 },
                new Level { Id = 3, Difficulty = 3, Points = 300 },
                new Level { Id = 4, Difficulty = 4, Points = 400 },
                new Level { Id = 5, Difficulty = 5, Points = 500 }
                );
        }

        public void AddOptionsData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>().HasData(
               new Option { Id = 1, Description = "90 minutos", QuestionId = 1, Correct = true },
                new Option { Id = 2, Description = "163 minutos", QuestionId = 1, Correct = false },
                new Option { Id = 3, Description = "15 minutos", QuestionId = 1, Correct = false },
                new Option { Id = 4, Description = "69 minutos", QuestionId = 1, Correct = false },
                new Option { Id = 5, Description = "Ciclismo", QuestionId = 2, Correct = true },
                new Option { Id = 6, Description = "Natacion", QuestionId = 2, Correct = false },
                new Option { Id = 7, Description = "Atletismo", QuestionId = 2, Correct = false },
                new Option { Id = 8, Description = "Rugby", QuestionId = 2, Correct = false },
                new Option { Id = 9, Description = "Maria Isabel Urrutia", QuestionId = 3, Correct = false },
                new Option { Id = 10, Description = "Marimar", QuestionId = 3, Correct = false },
                new Option { Id = 11, Description = "Charlotte Reinagle Cooper", QuestionId = 3, Correct = true },
                new Option { Id = 12, Description = "Beatrice Antonella Alessia", QuestionId = 3, Correct = false },
                new Option { Id = 13, Description = "Jackie Chan", QuestionId = 4, Correct = false },
                new Option { Id = 14, Description = "Chuck Norris", QuestionId = 4, Correct = false },
                new Option { Id = 15, Description = "Bruce Lee", QuestionId = 4, Correct = true },
                new Option { Id = 16, Description = "Luke", QuestionId = 4, Correct = false },
                new Option { Id = 17, Description = "Kid Pambele", QuestionId = 5, Correct = false },
                new Option { Id = 18, Description = "Rocky Marciano", QuestionId = 5, Correct = true },
                new Option { Id = 19, Description = "Mike Tyson", QuestionId = 5, Correct = false },
                new Option { Id = 20, Description = "Muhammed Ali", QuestionId = 5, Correct = false },
                new Option { Id = 21, Description = "5", QuestionId = 6, Correct = false },
                new Option { Id = 22, Description = "1", QuestionId = 6, Correct = true },
                new Option { Id = 23, Description = "8", QuestionId = 6, Correct = false },
                new Option { Id = 24, Description = "6", QuestionId = 6, Correct = false },
                new Option { Id = 25, Description = "9363", QuestionId = 7, Correct = false },
                new Option { Id = 26, Description = "9036", QuestionId = 7, Correct = true },
                new Option { Id = 27, Description = "963", QuestionId = 7, Correct = false },
                new Option { Id = 28, Description = "9360", QuestionId = 7, Correct = false },
                new Option { Id = 29, Description = "60", QuestionId = 8, Correct = false },
                new Option { Id = 30, Description = "30", QuestionId = 8, Correct = false },
                new Option { Id = 31, Description = "10", QuestionId = 8, Correct = true },
                new Option { Id = 32, Description = "20", QuestionId = 8, Correct = false },
                new Option { Id = 33, Description = "17/13", QuestionId = 9, Correct = false },
                new Option { Id = 34, Description = "2", QuestionId = 9, Correct = false },
                new Option { Id = 35, Description = "7/8", QuestionId = 9, Correct = true },
                new Option { Id = 36, Description = "4", QuestionId = 9, Correct = false },
                new Option { Id = 37, Description = "9", QuestionId = 10, Correct = false },
                new Option { Id = 38, Description = "-9", QuestionId = 10, Correct = true },
                new Option { Id = 39, Description = "-3", QuestionId = 10, Correct = false },
                new Option { Id = 40, Description = "3", QuestionId = 10, Correct = false },
                new Option { Id = 41, Description = "Nilo", QuestionId = 11, Correct = false },
                new Option { Id = 42, Description = "El amazonas", QuestionId = 11, Correct = true },
                new Option { Id = 43, Description = "Medellin", QuestionId = 11, Correct = false },
                new Option { Id = 44, Description = "Sena", QuestionId = 11, Correct = false },
                new Option { Id = 45, Description = "Armenia", QuestionId = 12, Correct = false },
                new Option { Id = 46, Description = "Rumania", QuestionId = 12, Correct = true },
                new Option { Id = 47, Description = "Ukrania", QuestionId = 12, Correct = false },
                new Option { Id = 48, Description = "Uruguay", QuestionId = 12, Correct = false },
                new Option { Id = 49, Description = "Asereje", QuestionId = 13, Correct = false },
                new Option { Id = 50, Description = "Princess of the universe", QuestionId = 13, Correct = false },
                new Option { Id = 51, Description = "Oda a la alegria", QuestionId = 13, Correct = true },
                new Option { Id = 52, Description = "Warriors of metal", QuestionId = 13, Correct = false },
                new Option { Id = 53, Description = "Palomas", QuestionId = 14, Correct = false },
                new Option { Id = 54, Description = "Golondrinas", QuestionId = 14, Correct = false },
                new Option { Id = 55, Description = "Murcielagos", QuestionId = 14, Correct = true },
                new Option { Id = 56, Description = "Gallinas", QuestionId = 14, Correct = false },
                new Option { Id = 57, Description = "Dexter", QuestionId = 15, Correct = false },
                new Option { Id = 58, Description = "Gregor Mendel", QuestionId = 15, Correct = true },
                new Option { Id = 59, Description = "Albert Einstein", QuestionId = 15, Correct = false },
                new Option { Id = 60, Description = "Isaac Newton", QuestionId = 15, Correct = false },
                new Option { Id = 61, Description = "Rap", QuestionId = 16, Correct = false },
                new Option { Id = 62, Description = "Trap", QuestionId = 16, Correct = true },
                new Option { Id = 63, Description = "Rock", QuestionId = 16, Correct = false },
                new Option { Id = 64, Description = "R&BMB", QuestionId = 16, Correct = false },
                new Option { Id = 65, Description = "Roobie Williams", QuestionId = 17, Correct = false },
                new Option { Id = 66, Description = "Rihanna", QuestionId = 17, Correct = true },
                new Option { Id = 67, Description = "R-Kelly", QuestionId = 17, Correct = false },
                new Option { Id = 68, Description = "Sting", QuestionId = 17, Correct = false },
                new Option { Id = 69, Description = "Goes", QuestionId = 18, Correct = false },
                new Option { Id = 70, Description = "Pedro", QuestionId = 18, Correct = false },
                new Option { Id = 71, Description = "Antonio", QuestionId = 18, Correct = true },
                new Option { Id = 72, Description = "ILuwding", QuestionId = 18, Correct = false },
                new Option { Id = 73, Description = "Metallica", QuestionId = 19, Correct = false },
                new Option { Id = 74, Description = "Def leppard", QuestionId = 19, Correct = false },
                new Option { Id = 75, Description = "Led Zeppelin", QuestionId = 19, Correct = true },
                new Option { Id = 76, Description = "Iron Maiden", QuestionId = 19, Correct = false },
                new Option { Id = 77, Description = "Freddy Mercury", QuestionId = 20, Correct = false },
                new Option { Id = 78, Description = "Giacomo Puccini", QuestionId = 20, Correct = true },
                new Option { Id = 79, Description = "Mozart", QuestionId = 20, Correct = false },
                new Option { Id = 80, Description = "Laura Pausini", QuestionId = 20, Correct = false },
                new Option { Id = 81, Description = "ADN", QuestionId = 21, Correct = false },
                new Option { Id = 82, Description = "Celula", QuestionId = 21, Correct = true },
                new Option { Id = 83, Description = "Aire", QuestionId = 21, Correct = false },
                new Option { Id = 84, Description = "Tejido", QuestionId = 21, Correct = false },
                new Option { Id = 85, Description = "Menbrana", QuestionId = 22, Correct = false },
                new Option { Id = 86, Description = "Nucleo", QuestionId = 22, Correct = true },
                new Option { Id = 87, Description = "Citoplasma", QuestionId = 22, Correct = false },
                new Option { Id = 88, Description = "Cromosoma", QuestionId = 22, Correct = false },
                new Option { Id = 89, Description = "Yegua", QuestionId = 23, Correct = false },
                new Option { Id = 90, Description = "Unicornio", QuestionId = 23, Correct = false },
                new Option { Id = 91, Description = "Mulo", QuestionId = 23, Correct = true },
                new Option { Id = 92, Description = "Potro", QuestionId = 23, Correct = false },
                new Option { Id = 93, Description = "Solidos", QuestionId = 24, Correct = false },
                new Option { Id = 94, Description = "Minerales", QuestionId = 24, Correct = false },
                new Option { Id = 95, Description = "Gasese nobles", QuestionId = 24, Correct = true },
                new Option { Id = 96, Description = "Metales", QuestionId = 24, Correct = false },
                new Option { Id = 97, Description = "Hongos", QuestionId = 25, Correct = false },
                new Option { Id = 98, Description = "Levaduras", QuestionId = 25, Correct = true },
                new Option { Id = 99, Description = "Microbios", QuestionId = 25, Correct = false },
                new Option { Id = 100, Description = "Bacterias", QuestionId = 25, Correct = false }
              );
        }

        public void AddQuestionsData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
           new Question { Id = 1, Description = "¿Cuánto dura un partido de fútbol?", CategoryId = 1 },
            new Question { Id = 2, Description = "¿Qué tipo de competición es el Giro de Italia?", CategoryId = 1 },
            new Question { Id = 3, Description = "¿Quién fue la primera mujer en ganar una medalla olímpica?", CategoryId = 1 },
            new Question { Id = 4, Description = "¿Quién inventó el arte marcial llamado Jeet Kune Do?", CategoryId = 1 },
            new Question { Id = 5, Description = "¿Quién fue el único campeón de boxeo de pesos pesados en no conocer derrota?", CategoryId = 1 },
            new Question { Id = 6, Description = "¿Cuántos meses tienen 28 días?", CategoryId = 2 },
            new Question { Id = 7, Description = "¿Cuál es la representación gráfica del número nueve mil treinta y seis?", CategoryId = 2 },
            new Question { Id = 8, Description = "Juan tiene 20 años menos que su padre y este tiene el triple de los años de su hijo. ¿Qué edad tiene su padre?", CategoryId = 2 },
            new Question { Id = 9, Description = "¿7/5 + 2/3 - 1 =? ", CategoryId = 2 },
            new Question { Id = 10, Description = "¿(-3)³ + (-2)³ - (-3)³ + (-1)³ =?", CategoryId = 2 },
            new Question { Id = 11, Description = "¿Cuál es el río más largo del mundo?", CategoryId = 3 },
            new Question { Id = 12, Description = "¿Dónde está Transilvania?", CategoryId = 3 },
            new Question { Id = 13, Description = "¿Cuál es el himno de la Unión Europea?", CategoryId = 3 },
            new Question { Id = 14, Description = "¿Cuáles son los únicos mamíferos que pueden volar?", CategoryId = 3 },
            new Question { Id = 15, Description = "¿Quién ideó las leyes de la herencia genética?", CategoryId = 3 },
            new Question { Id = 16, Description = "¿Cómo se denomina al subgénero musical del rap que mezcla rap, hip hop y dubstep?", CategoryId = 4 },
            new Question { Id = 17, Description = "¿Cuál es el nombre artístico de Robyn Fenty?", CategoryId = 4 },
            new Question { Id = 18, Description = "¿Cuál es el nombre de pila del compositor clásico Vivaldi?", CategoryId = 4 },
            new Question { Id = 19, Description = "¿Qué banda formó el músico inglés Jimmy Page en 1968?", CategoryId = 4 },
            new Question { Id = 20, Description = "¿Qué compositor creó la bella Madama Butterfly?", CategoryId = 4 },
            new Question { Id = 21, Description = "¿Cómo se llama el componente mínimo que forma a los seres vivos?", CategoryId = 5 },
            new Question { Id = 22, Description = "La información genética en las células se localiza:", CategoryId = 5 },
            new Question { Id = 23, Description = "Al descendiente del cruce de un asno y una yegua se le conoce como:", CategoryId = 5 },
            new Question { Id = 24, Description = "La columna más a la derecha de la tabla periódica esta compuesta por:", CategoryId = 5 },
            new Question { Id = 25, Description = "Para el pan y para la cerveza se utilizan para fermentar:", CategoryId = 5 }
            );
        }
    }
}
