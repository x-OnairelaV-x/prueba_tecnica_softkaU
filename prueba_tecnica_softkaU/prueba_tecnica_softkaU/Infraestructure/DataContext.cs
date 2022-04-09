using Microsoft.EntityFrameworkCore;
using prueba_tecnica_softkaU.DataSeeding;
using prueba_tecnica_softkaU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prueba_tecnica_softkaU.Infraestructure
{
    public class DataContext: DbContext
    {
        ISeedData seedData;
        public DataContext(DbContextOptions<DataContext> options  ) : base (options)
        {
            seedData = new SeedData();
        }

        protected override  void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                         .HasIndex(p => new { p.Id })
                         .IsUnique();

            modelBuilder.Entity<Level>()
                .HasIndex(p => new { p.Id })
                .IsUnique();

            modelBuilder.Entity<Level>()
                .HasIndex(p => new { p.Difficulty })
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(p => new { p.Id })
                .IsUnique();

            modelBuilder.Entity<Category>().HasOne(d => d.Level)
                .WithMany(p => p.Categories)
                .HasForeignKey(d => new { d.LevelId })
                .HasConstraintName("LevelId");

            modelBuilder.Entity<Question>()
                        .HasIndex(p => new { p.Id })
                        .IsUnique();

            modelBuilder.Entity<Question>().HasOne(d => d.Category)
                        .WithMany(p => p.Questions)
                        .HasForeignKey(d => new { d.CategoryId })
                        .HasConstraintName("CategoryId");

            modelBuilder.Entity<Option>()
                     .HasIndex(p => new { p.Id })
                     .IsUnique();

            modelBuilder.Entity<Option>().HasOne(d => d.Question)
             .WithMany(p => p.Options)
             .HasForeignKey(d => new { d.QuestionId })
             .HasConstraintName("QuestionId");

            modelBuilder.Entity<Round>()
                     .HasIndex(p => new { p.Id })
                     .IsUnique();

            modelBuilder.Entity<Round>().HasOne(d => d.Option)
                     .WithMany(p => p.Rounds)
                     .HasForeignKey(d => new { d.OptionId })
            .HasConstraintName("OptionId");

            modelBuilder.Entity<Round>().HasOne(d => d.Match)
                     .WithMany(p => p.Rounds)
                     .HasForeignKey(d => new { d.MatchId })
                     .HasConstraintName("MatchId");

            modelBuilder.Entity<Match>()
                     .HasIndex(p => new { p.Id })
                     .IsUnique();

            modelBuilder.Entity<Match>().HasOne(d => d.Player)
                     .WithMany(p => p.Matches)
                     .HasForeignKey(d => new { d.PlayerId })
                     .HasConstraintName("PlayerId");

            seedData.AddLevelData(modelBuilder);
            seedData.AddCategoryData(modelBuilder);
            seedData.AddQuestionsData(modelBuilder);
            seedData.AddOptionsData(modelBuilder);

        }

    }
}

