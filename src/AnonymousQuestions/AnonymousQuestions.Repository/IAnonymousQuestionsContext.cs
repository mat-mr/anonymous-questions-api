using AnonymousQuestions.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnonymousQuestions.Repository
{
    public interface IAnonymousQuestionsContext
    {
        DbSet<Question> Questions { get; }
    }
}
