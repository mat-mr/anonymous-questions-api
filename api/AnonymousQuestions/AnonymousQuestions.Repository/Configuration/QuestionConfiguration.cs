using AnonymousQuestions.Domain;
using Microsoft.EntityFrameworkCore;

namespace AnonymousQuestions.Repository.Configuration
{
    public class QuestionConfiguration : EntityConfiguration
    {
        public QuestionConfiguration(ModelBuilder modelBuilder) 
            : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            _modelBuilder.Entity<Question>()
                .HasKey(q => q.Id);

            _modelBuilder.Entity<Question>()
                .Property(q => q.Title)
                .IsRequired();

            _modelBuilder.Entity<Question>()
                .Property(q => q.Body)
                .IsRequired();

            _modelBuilder.Entity<Question>()
                .Property(q => q.Date)
                .IsRequired();

            _modelBuilder.Entity<Question>()
                .HasMany(q => q.Replies)
                .WithOne()
                .IsRequired();
        }
    }
}
