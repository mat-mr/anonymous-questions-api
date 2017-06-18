using AnonymousQuestions.Domain;
using Microsoft.EntityFrameworkCore;

namespace AnonymousQuestions.Repository.Context
{
    public interface IApiContext
    {
        DbSet<Question> Questions { get; }

        DbSet<Reply> Replies { get; }
    }
}
