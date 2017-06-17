using AnonymousQuestions.Domain;
using System;

namespace AnonymousQuestions.Repository
{
    public static class TestData
    {
        public static void CreateData(ApiContext context)
        {
            var question1 = new Question
            {
                Title = "Como fazer uma API?",
                Body = "Gostaria de saber como fazer uma API restful.",
                Date = new DateTime(2017, 3, 3)
            };

            var question2 = new Question
            {
                Title = "Fortran 90",
                Body = "Como se usa essa linguagem tão moderna?",
                Date = new DateTime(2017, 3, 3)
            };

            context.Questions.Add(question1);
            context.Questions.Add(question2);

            context.SaveChanges();
        }
    }
}
