using AnonymousQuestions.Domain;
using AnonymousQuestions.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AnonymousQuestions.Repository.Context
{
    public class ApiContext : DbContext, IApiContext
    {
        public DbSet<Question> Questions { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new QuestionConfiguration(modelBuilder).Configure();
        }
    }
}
