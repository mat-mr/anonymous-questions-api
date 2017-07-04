using AnonymousQuestions.Domain;
using System.Collections.Generic;

namespace AnonymousQuestions.Repository.Data
{
    public static class QuestionData
    {
        private static List<Question> questions;

        static QuestionData()
        {
            CreateQuestions();
            BuildRelationship();
        }

        public static List<Question> GetAll()
        {
            return questions;
        }

        private static Question CreateQuestion(long id, string title, string body)
        {
            return new Question(id, title, body);
        }

        private static void CreateQuestions()
        {
            questions = new List<Question>
            {
                CreateQuestion(1, "Como fazer uma API?", "Gostaria de saber como fazer uma API restful."),
                CreateQuestion(2, "Fortran 90", "Como se usa essa linguagem tão moderna?")
            };
        }

        private static void BuildRelationship()
        {
            ReplyData.GetAll().ForEach(r => questions.Find(q => q.Id == 1).AddReply(r));
        }
    }
}
