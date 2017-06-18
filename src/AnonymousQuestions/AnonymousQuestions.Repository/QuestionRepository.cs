using AnonymousQuestions.Domain;
using AnonymousQuestions.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousQuestions.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IAnonymousQuestionsContext _context;

        public QuestionRepository(IAnonymousQuestionsContext context)
        {
            _context = context;
        }

        public Question Find(long id)
        {
            return _context.Questions.Find(id);
        }

        public List<Question> FindAll()
        {
            return _context.Questions.ToList();
        }

        public void Add(Question question)
        {
            _context.Questions.Add(question);
        }

        public void Remove(long id)
        {
            var question = _context.Questions.Find(id);
            _context.Questions.Remove(question);
        }

        public void Update(Question question)
        {
            _context.Questions.Update(question);
            //_context.SaveChanges();
        }
    }
}
