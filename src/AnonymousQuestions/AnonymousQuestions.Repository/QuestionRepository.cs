using AnonymousQuestions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousQuestions.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApiContext _context;

        public QuestionRepository(ApiContext context)
        {
            _context = context;
        }

        public Question Find(long id)
        {
            return _context.Questions.Find(id);
        }

        public IEnumerable<Question> FindAll()
        {
            return _context.Questions.ToList();
        }

        public void Add(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }

        public void Remove(long id)
        {
            var question = _context.Questions.Find(id);
            _context.Questions.Remove(question);
            _context.SaveChanges();
        }

        public void Update(Question question)
        {
            _context.Questions.Update(question);
            _context.SaveChanges();
        }
    }
}
