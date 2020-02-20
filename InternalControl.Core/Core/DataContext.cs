using InternalControl.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternalControl.Core.Core
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormQuestion>()
            .HasKey(f => new { f.FormId, f.QuestionId });
            modelBuilder.Entity<FormQuestion>()
                .HasOne(f => f.Form)
                .WithMany(i => i.FormQuestions)
                .HasForeignKey(bc => bc.FormId);
            modelBuilder.Entity<FormQuestion>()
                .HasOne(bc => bc.Question)
                .WithMany(c => c.FormQuestions)
                .HasForeignKey(bc => bc.QuestionId);
        }

        public virtual DbSet<QuestionModel> Questions { get; set; }
        public virtual DbSet<IndicatorsModel> Indicators { get; set; }
        public virtual DbSet<GroupOfIndicatorsModel> GroupOfIndicators { get; set; }
        public virtual DbSet<TypeOfForm> TypeOfForm { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormQuestion> FormQuestions { get; set; }
           
    }
}
