using AnonymousQuestions.Domain;
using AnonymousQuestions.Repository.Context;
using System.Linq;

namespace AnonymousQuestions.Repository
{
    public static class TestData
    {
        public static void CreateData(ApiContext context)
        {
            var question1 = new Question(1, "Como fazer uma API?", "Gostaria de saber como fazer uma API restful.");
            var question2 = new Question(2, "Fortran 90", "Como se usa essa linguagem tão moderna?");

            var reply1 = new Reply(1, "Bernardo", "Vou ensinar amanhã na aula.");
            var reply2 = new Reply(2, "Nunes", "et cetera e tal.");

            context.Replies.Add(reply1);
            context.Questions.Add(question1);
            context.Questions.Add(question2);

            context.Questions.Find(question1.Id).AddReply(reply1);
            context.Questions.Find(question1.Id).AddReply(reply2);

            context.SaveChanges();


            var questions = context.Questions.ToList();
        }
    }
}
