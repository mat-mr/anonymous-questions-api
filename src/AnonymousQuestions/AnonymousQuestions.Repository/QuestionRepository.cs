using AnonymousQuestions.Domain;
using AnonymousQuestions.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnonymousQuestions.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApiContext _context;

        public QuestionRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<Question> FindAsync(long id)
        {
            return await _context.Questions.Where(q => q.Id == id)
                                           .Include(q => q.Replies)
                                           .FirstOrDefaultAsync();
        }

        public async Task<List<Question>> FindAllAsync()
        {
            return await _context.Questions.Include(q => q.Replies)
                                           .ToListAsync();
        }

        public async Task<List<Question>> FindAllUnansweredAsync()
        {
            return await _context.Questions.Where(q => !q.Replies.Any())
                                           .ToListAsync();
        }

        public async Task<Question> AddAsync(Question question)
        {
            var savedQuestion = _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return savedQuestion.Entity;
        }

        public async Task RemoveAsync(long id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }
    }
}
