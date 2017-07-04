using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnonymousQuestions.Domain
{
    public interface IQuestionRepository
    {
        Task<Question> FindAsync(long id);
        Task<List<Question>> FindAllAsync();
        Task<List<Question>> FindAllUnansweredAsync();
        Task<Question> AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task RemoveAsync(long id);
    }
}
