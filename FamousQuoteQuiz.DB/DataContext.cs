using FamousQuoteQuiz.BL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamousQuoteQuiz.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GameQuestions>()
             .HasKey(x => new { x.GameId, x.QuestionId });

            modelBuilder.Entity<QuestionAuthors>()
          .HasKey(x => new { x.AuthorId, x.QuestionId });

            modelBuilder.Entity<QuestionAuthors>()
                .HasOne(x=>x.Question)
                .WithMany(x=>x.EstimatedAnswers)
                .HasForeignKey(x=>x.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Question>()
                .HasOne(x => x.Quote)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

   


        }
    }
}
