using AnonymousQuestions.Domain;
using Microsoft.EntityFrameworkCore;

namespace AnonymousQuestions.Repository.Context
{
    public interface IAnonymousQuestionsContext
    {
        DbSet<Question> Questions { get; }
    }
}
