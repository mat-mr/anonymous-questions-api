using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousQuestions.Domain
{
    public interface IQuestionRepository
    {
        Question Find(long id);
        List<Question> FindAll();
        void Add(Question question);
        void Update(Question question);
        void Remove(long id);
    }
}
