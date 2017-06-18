using AnonymousQuestions.Domain;
using AnonymousQuestions.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AnonymousQuestions.Repository.Context
{
    public class AnonymousQuestionsContext : DbContext, IAnonymousQuestionsContext
    {
        public DbSet<Question> Questions { get; set; }

        public AnonymousQuestionsContext(DbContextOptions<AnonymousQuestionsContext> options) : base(options)
        {
        }
.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new QuestionConfiguration(modelBuilder).Configure();
        }
    }
}
