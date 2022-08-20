using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentProject.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<assessments>().HasOne(a => a.relations).WithOne(b => b.assessment).HasForeignKey<assessment_questions_relation>(c=>c.assessment_id);
            modelBuilder.Entity<assessments>(b =>
            {
                b.HasKey(e => e.id);
              b.Property(x => x._id).HasDefaultValueSql("NEWID()");
                b.Property(z => z.create_at).HasDefaultValueSql("Getdate()");
            });
            modelBuilder.Entity<assessment_answers>(b =>
            {
                b.HasKey(e => e.id);
                b.Property(x => x._id).HasDefaultValueSql("NEWID()");
                b.Property(z => z.create_at).HasDefaultValueSql("Getdate()");
            });
            modelBuilder.Entity<assessment_enrols>().HasOne<assessments>(a => a.assessment).WithMany(b => b.enrols).HasForeignKey(c => c.assessment_id);
            modelBuilder.Entity<assessment_enrols>(b =>
            {
                b.HasKey(e => e.id);
                b.Property(x => x._id).HasDefaultValueSql("NEWID()");
                b.Property(z => z.create_at).HasDefaultValueSql("Getdate()");
            });

            modelBuilder.Entity<assessment_questions>().HasOne(a => a.text_id).WithOne(b => b.question).HasForeignKey<assessment_text>(c => c.question_id);
            modelBuilder.Entity<assessment_questions>().HasOne(a => a.true_False_id).WithOne(b => b.question).HasForeignKey<assessment_true_false>(c => c.question_id);
            
            modelBuilder.Entity<assessment_questions>(b =>
            {
                b.HasKey(e => e.id);
                b.Property(x => x._id).HasDefaultValueSql("NEWID()");
                b.Property(z => z.create_at).HasDefaultValueSql("Getdate()");
            });
            modelBuilder.Entity<assessment_questions_relation>().HasOne<assessment_questions>(a => a.question).WithMany(b => b.relations).HasForeignKey(c => c.question_id);
            modelBuilder.Entity<assessment_questions_relation>().HasOne<assessments>(a => a.assessment).WithMany(b => b.relations).HasForeignKey(c => c.assessment_id);
            modelBuilder.Entity<assessment_questions_relation>(b =>
            {
                b.HasKey(e => e.id);
                b.Property(x => x._id).HasDefaultValueSql("NEWID()");
                b.Property(z => z.create_at).HasDefaultValueSql("Getdate()");
            });

           
            
            modelBuilder.Entity<assessment_text>().HasKey(assessment_text => new {
                 assessment_text.id

             });
            
           modelBuilder.Entity<assessment_true_false>(b =>
           {
               b.HasKey(e => e.id);
               b.Property(x => x._id).HasDefaultValueSql("NEWID()");
               b.Property(z => z.create_at).HasDefaultValueSql("Getdate()");
           });
            modelBuilder.Entity<assessment_match>().HasOne<assessment_questions>(a => a.question).WithMany(b => b.match).HasForeignKey(c => c.question_id);
            modelBuilder.Entity<assessment_match>(b =>
            {
                b.HasKey(e => e.id);
                b.Property(x => x._answer_id).HasDefaultValueSql("NEWID()");
                b.Property(x => x._question_id).HasDefaultValueSql("NEWID()");
                b.Property(z => z.create_at).HasDefaultValueSql("Getdate()");
            });
            modelBuilder.Entity<assessment_options>().HasOne<assessment_questions>(a => a.question).WithMany(b => b.option).HasForeignKey(c => c.question_id);
            modelBuilder.Entity<assessment_options>(b =>
            {
                b.HasKey(e => e.id);
                b.Property(x => x._id).HasDefaultValueSql("NEWID()");
                b.Property(z => z.create_at).HasDefaultValueSql("Getdate()");
            });

        }
        public DbSet<assessments> assessments { get; set; }
        public DbSet<assessment_answers> assessment_answers { get; set; }
        public DbSet<assessment_enrols> assessment_enrols { get; set; }
        public DbSet<assessment_match> assessment_match { get; set; }
        public DbSet<assessment_options> assessment_options { get; set; }
        public DbSet<assessment_questions> assessment_questions { get; set; }
        public DbSet<assessment_questions_relation> assessment_questions_relation { get; set; }
        public DbSet<assessment_text> assessment_text { get; set; }
        public DbSet<assessment_true_false> assessment_true_false { get; set; }
        public DbSet<users> users { get; set; }
     

    }
}
