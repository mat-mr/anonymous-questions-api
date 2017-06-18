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
                Date = DateTime.Now
            };

            var question2 = new Question
            {
                Title = "Fortran 90",
                Body = "Como se usa essa linguagem tão moderna?",
                Date = DateTime.Now.AddDays(15)
            };

            var reply1 = new Reply
            {
                Author = "Bernardo",
                Body = "Vou ensinar amanhã na aula.",
                Date = DateTime.Now.AddHours(3),
            };

            var reply2 = new Reply
            {
                Author = "Nunes",
                Body = "et cetera e tal.",
                Date = DateTime.Now.AddHours(4),
            };

            context.Replies.Add(reply1);
            context.Questions.Add(question1);
            context.Questions.Add(question2);
            context.Questions.Find(question1.Id).AddReply(reply1);
            context.Questions.Find(question1.Id).AddReply(reply2);

            context.SaveChanges();
        }
    }
}
