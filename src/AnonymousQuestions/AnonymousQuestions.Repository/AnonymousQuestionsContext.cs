using AnonymousQuestions.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnonymousQuestions.Repository
{
    public class AnonymousQuestionsContext : DbContext
    {
        public AnonymousQuestionsContext(DbContextOptions<AnonymousQuestionsContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
    }
}
