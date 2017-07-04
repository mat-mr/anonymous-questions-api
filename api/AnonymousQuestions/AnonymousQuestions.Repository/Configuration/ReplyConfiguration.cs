using AnonymousQuestions.Domain;
using Microsoft.EntityFrameworkCore;

namespace AnonymousQuestions.Repository.Configuration
{
    public class ReplyConfiguration : EntityConfiguration
    {
        public ReplyConfiguration(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Configure()
        {
            this._modelBuilder.Entity<Reply>()
                .HasKey(r => r.Id);

            this._modelBuilder.Entity<Reply>()
                .Property(r => r.Author)
                .IsRequired();

            this._modelBuilder.Entity<Reply>()
                .Property(r => r.Body)
                .IsRequired();

            this._modelBuilder.Entity<Reply>()
                .Property(r => r.Date)
                .IsRequired();
        }
    }
}
